using System;
using Raylib_cs;

class Program
{
    public static bool gameActive = true;
    static void Main(string[] args)
    {

        Raylib.InitWindow(1920, 1080, "Menu");
        Raylib.SetTargetFPS(120);
        //Raylib.ToggleFullscreen();

        QuizManager.LoadTextures();
        QuizManager.LoadQuestions();

        // Updates the gamestate
        while (gameActive)
        {
            QuizManager.Update();

            Raylib.BeginDrawing();
            Raylib.ClearBackground(new Color(255, 255, 255, 0));

            if (gameActive) QuizManager.DrawQuestion();

            Raylib.EndDrawing();
        }

        // Writes the questions
        for (int i = 0; i < QuizManager.allQuestions.Count; i++)
        {
            Console.Write(QuizManager.allQuestions[i].question + ": " + QuizManager.allQuestions[i].selectedAnswer);
            Console.WriteLine("\n");
        }
        Raylib.CloseWindow();

        // Makes so that u cant exit out unless u use the x button in the right top corner
        while (true)
        {
            Console.ReadLine();
        }
    }
}
