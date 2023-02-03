using System.IO;
using UnityEditor;
using UnityEngine;
using OfficeOpenXml;

public class CreateIngredientsFromExcel : MonoBehaviour
{
    [MenuItem("Tools/Create Ingredients From Excel")]
    public static void CreateIngredients()
    {
        // Read the excel file
        FileInfo file = new FileInfo("path/to/ingredients.xlsx");
        using (ExcelPackage package = new ExcelPackage(file))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

            int rowCount = worksheet.Dimension.End.Row;

            // Loop through each row of the worksheet
            for (int row = 2; row <= rowCount; row++)
            {
                // Create a new instance of the Ingredient ScriptableObject
                Ingredient ingredient = ScriptableObject.CreateInstance<Ingredient>();

                // Read the values from the Excel sheet and set the properties of the ingredient
                ingredient.name = worksheet.Cells[row, 1].Value.ToString();
                ingredient.weight = (int)worksheet.Cells[row, 2].Value;
                ingredient.price = (float)worksheet.Cells[row, 3].Value;
                ingredient.flavour.umami = (int)worksheet.Cells[row, 4].Value;
                ingredient.flavour.sour = (int)worksheet.Cells[row, 5].Value;
                ingredient.flavour.sweet = (int)worksheet.Cells[row, 6].Value;
                ingredient.flavour.spicy = (int)worksheet.Cells[row, 7].Value;
                ingredient.flavour.bitter = (int)worksheet.Cells[row, 8].Value;

                // Create an asset for the ingredient
                AssetDatabase.CreateAsset(ingredient, "Assets/Ingredients/" + ingredient.name + ".asset");
            }

            // Refresh the AssetDatabase to see the new assets
            AssetDatabase.Refresh();
        }
    }
}