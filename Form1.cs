namespace Activity_5
{
    using System.IO;

    // Breanna Gernon
    // CST-150
    // November 19, 2022
    // I used source code from the following websites to complete this assignment:
    // https://www.dotnetperls.com/string-compare - This site was used to learn how to compare two strings together effectively.
    // https://stackoverflow.com/questions/10373061/multi-line-textbox-to-array-c-sharp - This site was used to learn how to convert the info in a multiline textbox to an array.
    // I also used the textbook for some information in the form.
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
















        }

        //finds the first word alphabetically in the file
        public string firstWord(String[] wordList)
        {
            string firstAlphabetically = wordList[0];

            for (int i = 0; i < wordList.Length; i++)
            {
                if (firstAlphabetically.CompareTo(wordList[i]) == 1)
                {
                    firstAlphabetically = wordList[i];
                }
            }

            return "First word alphabetically: " + firstAlphabetically;
        }

        //finds the last word alphabetically in the file
        public String lastWord(String[] wordList)
        {
            String lastWord = wordList[0];

            for (int i = 0; i < wordList.Length; i++)
            {
                if (lastWord.CompareTo(wordList[i]) == -1)
                {
                    lastWord = wordList[i];
                }

            }

                return "Last word alphabetically: " + lastWord;
            
        }

        //finds the longest word in the file
        public String mostLetters(String[] wordList)
        {
            String mostLetters = wordList[0];
            Random randNumber = new Random();
            int randHolder;
            String[] tempArray = new String[2];
            

            for (int i = 0; i < wordList.Length; i++)
            {
                if (mostLetters.Length < wordList[i].Length)
                {
                    mostLetters = wordList[i];
                }

                else if (mostLetters.Length == wordList[i].Length)
                {
                    tempArray[0] = mostLetters;
                    tempArray[1] = wordList[i];
                    randHolder = randNumber.Next(0, 2);
                    mostLetters = tempArray[randHolder];
                }
            }


            return "Longest word: " + mostLetters;
        }

        //finds the number of vowels of each word in the file
        public int numOfVowels(String word)
        {
            int numVowels = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == 'a' || word[i] == 'e' || word[i]== 'i' || word[i] == 'o' || word[i] == 'u'
                    || word[i] == 'A' || word[i] == 'E' || word[i] == 'I' || word[i] == 'O' || word[i] == 'U')
                {
                    numVowels++;
                }
            }

            return numVowels;
        }

        //finds the word with the most vowels in the file
        public String mostVowel(String[] wordList)
        {
            String mostVowel = wordList[0];
            Random randNumber = new Random();
            int randHolder;
            String[] tempArray = new String[2];

            for (int i = 0; i < wordList.Length; i++)
            {
                if (numOfVowels(mostVowel) < numOfVowels(wordList[i]))
                {
                    mostVowel = wordList[i];
                }

                else if (numOfVowels(mostVowel) == numOfVowels(wordList[i]))
                {
                    tempArray[0] = mostVowel;
                    tempArray[1] = wordList[i];
                    randHolder = randNumber.Next(0, 2);
                    mostVowel = tempArray[randHolder];
                }
            }

            return "Most vowels: " +  mostVowel;
        }

        //opens the File and reads it, performs all functions needed
        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader inputFile;
            int count = 0;
            String fileName;
            String line;
            String lowerline;
            String alphaFirst;
            String alphaLast;
            String longestWord;
            String mostVowels;
            String[] resultArray = new String[4];

            //Checks to see if the user selects okay to open a file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                inputFile = new StreamReader(openFileDialog1.FileName);
                fileName = openFileDialog1.FileName;
                fileNameBox.Text = fileName;
                String[] wordArray = System.IO.File.ReadAllLines(fileName);

                
                //changes all lines in file to lowercase and adds them to an array
                while (!inputFile.EndOfStream)
                {
                    line = inputFile.ReadLine();
                    lowerline = line.ToLower();
                    wordArray[count] = lowerline;
                    count++;

                }

                resultBox.Text += "All Words in File, Lowercase: \r\n";
                
                //adds all lowercase words to the textbox
                for (int i = 0; i < wordArray.Length; i++)
                {
                    resultBox.Text += wordArray[i] +"\r\n";
                }

                inputFile.Close();

                resultBox.Text += "\n" + " ---------- \r\n";

               alphaFirst =  firstWord(wordArray);
               alphaLast = lastWord(wordArray);
               longestWord = mostLetters(wordArray);
               mostVowels = mostVowel(wordArray);
               resultArray[0] = alphaFirst;
               resultArray[1] = alphaLast;
               resultArray[2] = longestWord;
               resultArray[3] = mostVowels;
          
                //adds all results to the textbox
               for (int i = 0; i < 4; i++)
                {
                    resultBox.Text += resultArray[i] + "\r\n";      
                }

              
              


            }

            else
                MessageBox.Show("Operation canceled.");



        }

        //writes the results to a file
        private void saveButton_Click(object sender, EventArgs e)
        {
            String outputFile;
            String[] results = resultBox.Text.Split('\n');


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)

            {
                outputFile = saveFileDialog1.FileName;
                File.WriteAllLines(outputFile, results);


            }
        }

    }       
    
}