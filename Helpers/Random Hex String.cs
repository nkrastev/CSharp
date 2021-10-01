private static string RandomByteHexString(int size)
{            
    //random bytes generation
    Random rnd = new Random();
    Byte[] randomBytesArray = new Byte[size];
    rnd.NextBytes(randomBytesArray);

    //convertion to hex
    string resultHex = BitConverter.ToString(randomBytesArray).Replace("-", "");                        
    return resultHex.ToString();
}
