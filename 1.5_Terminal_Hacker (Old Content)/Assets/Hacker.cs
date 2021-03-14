using UnityEngine;

public class Hacker : MonoBehaviour
{

    string[] level1Passwords = {"books", "pencil", "table", "font", "word", "pen" };
    string[] level2Passwords = { "surgeon", "uniform", "operation", "medicine", "doctor", "pill" };
    //Start is called before the first frame update (the first thing the program does).
    //Game State
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    void Start()
    {
        print(level1Passwords[0]); //Samo da vidim na konzoli (test)
        ShowMainMenu();
    }

    void Update()
    {
        int index1 = Random.Range(0, level1Passwords.Length);
        print(index1);
        int index2 = Random.Range(0, level2Passwords.Length);
        print(index2);
    }
    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to Terminal Hacker.\nWhat would you like to hack into?");
        Terminal.WriteLine("Press 1 for the High School Network");
        Terminal.WriteLine("Press 2 for the City Hospital");
        Terminal.WriteLine("Enter your selection: ");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "Menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }

    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" );
        if (isValidLevelNumber) 
        {
            level = int.Parse(input); //Pretvara userov input iz str u int
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("You chose level 007, Mr. Bond ;).");
        }
        else
        {
            Terminal.WriteLine("Please chose a valid level or type 'menu' to return to Main Menu.");
        }
    }

    void StartGame()
    {
        print(level1Passwords.Length);
        print(level2Passwords.Length);
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch (level) 
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            default:
                Debug.LogError("Invalid level number");
                break; //Fail safe koji se vjv nikad nece ukljucit
        }
           
        Terminal.WriteLine("Please enter your password.\nHint: " + password.Anagram());
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            Terminal.WriteLine("Sorry, Try again.");
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        Terminal.WriteLine("Well done! You Won! :D\nTo return to the Main Menu type: Menu");
    }

}