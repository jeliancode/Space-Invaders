using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.Model;
public class ScoreManager
{
    private const string filePath = "scores.txt";

    public static void SaveScore(string playerName, string score)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{playerName},{score}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al guardar el puntaje: {ex.Message}");
        }
    }
}
