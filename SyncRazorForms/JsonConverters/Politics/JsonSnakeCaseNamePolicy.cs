using System.Text.Json;

namespace SyncRazorForms.JsonConverters.Politics;

public class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
         
        var chars = name.ToCharArray();
        var newString = new List<char>();
        
        foreach (var symbol in chars)
        {
            if (char.IsUpper(symbol))
            {
                
                newString.Add('_');
            }
            
            newString.Add(char.ToLower(symbol));
        }
        
        return string.Join("", newString);
    }
}