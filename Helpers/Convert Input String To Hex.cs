private static string ConvertToHex(string input)
        {
            var resultToHex = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(input);
            foreach (var t in bytes)
            {
                resultToHex.Append(t.ToString("X2"));
            }
            return resultToHex.ToString();
        }