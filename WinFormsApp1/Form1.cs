using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows.Forms;
using static WinFormsApp1.Form1;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Hash
        {
            public Hash() { Data = new(); }
            public Dictionary<int, Dictionary<int, int>> Data { get; set; }

            public void Save(int key1, int key2, int value)
            {
                // Check if the outer dictionary contains key1
                if (!Data.ContainsKey(key1))
                {
                    // If not, add a new entry with an inner dictionary
                    Data[key1] = new Dictionary<int, int>();
                }

                // Add or update the value in the inner dictionary
                Data[key1][key2] = value;
            }

            public int Get(int key1, int key2)
            {
                // Check if the outer dictionary and inner dictionary contain the keys
                if (Data.TryGetValue(key1, out var innerDict) && innerDict.TryGetValue(key2, out var value))
                {
                    // If both keys are found, return the value
                    return value;
                }
                else
                {
                    // If either key is not found, you may want to handle this case accordingly
                    // For now, I'll return a default value (you can choose a different approach)
                    return -1;
                }
            }
            public string GetAsString(int key1, int key2)
            {
                return Get(key1, key2).ToString();
            }
        }

        private void GeneratePairs()
        {

            int playersMax = checkbox_maxPlayers.Checked ? 24 : 12; // set it to 12 or 24
            int roundsMax = 0;
            Hash tournamentHash = new Hash();

            bool[] isPlaying = new bool[playersMax + 1];
            bool[] isPaired = new bool[playersMax + 1];
            int PlayerCount = 0;
            bool NeedDummy = false;
            bool Shuffle = checkbox_Shuffle.Checked;

            //--------------------------------------------------------------------
            // Initialization
            for (int player = 1; player <= playersMax; player++)
            {
                if (checkedListBox1.GetItemCheckState(player - 1) == CheckState.Checked)
                {
                    isPlaying[player] = true;
                    isPaired[player] = false;
                    PlayerCount++;
                }
                else
                {
                    isPlaying[player] = false;
                    isPaired[player] = false;
                }
            }



            //----------------------------------------------------------
            NeedDummy = PlayerCount % 2 != 0; PlayerCount = PlayerCount % 2 == 0 ? PlayerCount : PlayerCount + 1;
            isPlaying[0] = NeedDummy; isPaired[0] = !NeedDummy;
            roundsMax = PlayerCount - 1; // with or without dummy, it will always be even number - 1

            //--------------------------------------------------------------------
            // Pairing logic

            for (int round = 0; round < roundsMax; round++)
            {
                for (int player1 = 0; player1 <= playersMax; player1++)
                {
                    if ((!NeedDummy && player1 == 0) || !isPlaying[player1] || isPaired[player1]) { continue; }

                    int player2 = FindAvailablePlayer(player1);

                    tournamentHash.Save(round, player1, player2);
                    tournamentHash.Save(round, player2, player1);
                    isPaired[player1] = true;
                    isPaired[player2] = true;

                }

                // Reset isPaired array for the next round
                for (int i = 0; i <= playersMax; i++) { isPaired[i] = false; }

            }


            // 



            //--------------------------------------------------------------------
            int FindAvailablePlayer(int player1)
            {
                if (Shuffle)
                {
                    while (true)
                    {
                        int paired = countUnpairedPlayers();
                        if (paired > 2)
                        {
                            int random = getRandomPlayer();
                            if (!isPlaying[random] || player1 == random || isPaired[random])
                            {
                                continue;
                            }
                            return random;
                        }
                        else
                        {

                            int start = NeedDummy ? 0 : 1;
                            for (int player2 = start; player2 <= playersMax; player2++)
                            {
                                if ((!NeedDummy && player2 == 0) || !isPlaying[player1] || !isPlaying[player2] || player1 == player2 || isPaired[player2])
                                {
                                    continue;
                                }
                                return player2;
                            }
                        }

                    }



                }
                else
                {
                    for (int player2 = 0; player2 <= playersMax; player2++)
                    {
                        if ((!NeedDummy && player2 == 0) || !isPlaying[player1] || !isPlaying[player2] || player1 == player2 || isPaired[player2] || PairExists(player1, player2, tournamentHash))
                        {
                            continue;
                        }

                        return player2;
                    }

                    // If no available player is found among playing players, find the first player that hasn't been paired yet
                    for (int player2 = 0; player2 <= playersMax; player2++)
                    {
                        if ((!NeedDummy && player2 == 0) || !isPlaying[player1] || !isPlaying[player2] || player1 == player2 || isPaired[player2])
                        {
                            continue;
                        }
                        return player2;
                    }

                    // This should not happen in a correct implementation
                    throw new InvalidOperationException("Unable to find an available player.");
                }
                // This should not happen in a correct implementation
                throw new InvalidOperationException("Unable to find an available player.");
            }


            //--------------------------------------------------------------------
            bool PairExists(int p1, int p2, Hash whichHash)
            {
                if (p1 == p2) { return true; }
                for (int round = 0; round < roundsMax; round++)
                {
                    if (whichHash.Get(round, p1) == p2) { return true; }
                }

                return false;
            }
            //--------------------------------------------------------------------
            int countUnpairedPlayers()
            {
                int count = 0;
                for (int player2 = 0; player2 <= playersMax; player2++)
                {
                    if ((!NeedDummy && player2 == 0) && !isPlaying[player2]) { continue; }
                    if (isPaired[player2]) { continue; }
                    count++;
                }
                return count;
            }
            int getRandomPlayer()
            {
                Random random = new Random();
                int start = NeedDummy ? 0 : 1;
                int num = random.Next(start, playersMax);

                return num;
            }
            //-----------------------------------------------------------------------------------------
            // debug logic
            listBox1.Items.Clear();

            // MessageBox.Show("pairs: " + (CountRecords(tournamentHash) / 2).ToString());
            // MessageBox.Show(tournamentHash.Get(2, 2).ToString());
            int pairingN = 1; // Initialize pairingN outside the loop
            List<int> displayed = new();
            for (int rnd = 0; rnd < roundsMax; rnd++)
            {
                for (int i = 0; i <= playersMax; i++)
                {
                    if (!NeedDummy && i == 0) { continue; }
                    if (!isPlaying[i]) { continue; }
                    if (displayed.Contains(i)) { continue; }
                    int p1 = i;
                    int p2 = tournamentHash.Get(rnd, p1);
                    displayed.Add(p1);
                    displayed.Add(p2);


                    listBox1.Items.Add($"Round {rnd + 1}: Pairing {pairingN}. Player {p1} - Player {p2}");

                    pairingN++; // Increment pairingN for the next iteration

                }
                displayed.Clear();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            AddCheckboxesToCheckedListBox(12);

            GeneratePairs();




        }

        public int CountRecords(Hash hash)
        {
            int count = 0;


            foreach (var outerKey in hash.Data.Keys)
            {
                foreach (var innerKey in hash.Data[outerKey].Keys)
                {
                    count++;
                }
            }

            return count;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            GeneratePairs();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int players = int.Parse(comboBox2.Text);
            int rounds = 0;
            int pairsPerRound = 0;
            int totalPairs = 0;

            // If the number of players is odd, add a dummy player to make it even
            if (players % 2 != 0)
            {
                players++;
            }

            // Calculate the number of pairs
            totalPairs = (players * (players - 1)) / 2;

            // Calculate the number of rounds
            rounds = players - 1;

            // Calculate the number of pairs per round
            pairsPerRound = players / 2;


            // Providing additional information for odd number of players
            string explanation = players % 2 != 0 ? "\n(Because of an odd number of players,\n one player wins every round)" : "";



            Display.Text = $"For {players} players,\n there will be {rounds} round/s,\n each round has {pairsPerRound} pair/s,\n for a total of {totalPairs} pair/s.{explanation}";

            // Pairs for even number of players = (Players /2) * (Players -1)
            // Pairs for odd number of players = (Players+1) /2 * (Players)
        }
        private void AddCheckboxesToCheckedListBox(int numberOfCheckboxes)
        {

            checkedListBox1.Items.Clear();

            // Loop to add checkboxes to CheckedListBox
            for (int i = 1; i <= numberOfCheckboxes; i++)
            {
                // Create a checkbox item
                string checkboxText = "Player " + i;

                // Add the checkbox item to the CheckedListBox
                checkedListBox1.Items.Add(checkboxText);
            }
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_maxPlayers.Checked == false)
            {
                AddCheckboxesToCheckedListBox(12);
            }
            else
            {
                AddCheckboxesToCheckedListBox(24);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                sb.AppendLine(listBox1.Items[i].ToString());
            }
            Clipboard.SetText(sb.ToString());
        }
    }

}
