private static string ConvertToHex(string input)
{                        
    var bytes = Encoding.Unicode.GetBytes(input);            
    return BitConverter.ToString(bytes).Replace("-", "");
}
