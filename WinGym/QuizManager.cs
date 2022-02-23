using System.Collections.Generic;
using Raylib_cs;
using System.IO;
using System;
using System.Numerics;
public class QuizManager
{
    public static Dictionary<string, Texture2D> allTextures = new Dictionary<string, Texture2D>();
    public static List<Question> allQuestions = new List<Question>();
    public static int currentQuestion = 0;

    // Makes it possible to click the buttons for the different answers
    public static void Update()
    {
        for (int i = 0; i < 4; i++)
        {

            if (Raylib.GetMouseX() > i * (Raylib.GetScreenWidth() / 4) && Raylib.GetMouseX() < i * (Raylib.GetScreenWidth() / 4) + Raylib.GetScreenWidth() / 4)
                if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
                {
                    allQuestions[currentQuestion].selectedAnswer = allQuestions[currentQuestion].allAnswers[i];
                    currentQuestion++;
                }
        }

        if (currentQuestion > allQuestions.Count - 1)
        {
            Console.WriteLine("UWU");
            Program.gameActive = false;
        }
    }

    // Draws the textures for the four options (it works, idk how but it does)
    public static void DrawQuestion()
    {
        Question question = allQuestions[currentQuestion];
        Raylib.DrawText(question.question, Raylib.GetScreenWidth() / 2 - Raylib.MeasureText(question.question, 40) / 2, 10, 40, Color.BLACK);

        for (int i = 0; i < question.allAnswers.Length; i++)
        {
            Vector2 size = new Vector2(allTextures[question.allAnswers[i]].width, allTextures[question.allAnswers[i]].height);

            Rectangle sourceRec = new Rectangle(0, 0, size.X, size.Y);

            Rectangle destRec = new Rectangle((Raylib.GetScreenWidth() / 4) * i, 200, size.X * 0.2f, size.Y * 0.2f);

            Raylib.DrawTexturePro(allTextures[question.allAnswers[i]], sourceRec, destRec, new Vector2(0, 0), 0, Color.WHITE);
        }
    }

    // Questions and the 4 options/answers
    public static void LoadQuestions()
    {
        new Question("Vilken av dessa fyra representanter skulle passa bäst som Byggarbetare", new string[] { "1", "2", "3", "4" });
        new Question("Vem av dessa fyra karaktärer ser mest ut att passa in som en Ingenjör", new string[] { "1", "2", "3", "4" });
        new Question("Välj en av dessa fyra som du ser passar bäst in inom Sjukvården", new string[] { "1", "2", "3", "4" });
        new Question("Vilken av de fyra karaktärerna passar bäst in som en Kock på en Restaurang", new string[] { "1", "2", "3", "4" });
    }

    // Loads textures...
    public static void LoadTextures()
    {
        string root = @"textures\";

        string[] textures = Directory.GetFiles(root);
        foreach (string texture in textures)
        {
            allTextures.Add(Path.GetFileNameWithoutExtension(texture), Raylib.LoadTexture(texture));
        }
    }
}
