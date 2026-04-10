using System.Reflection.Metadata.Ecma335;

static string ComputeHash(string input)
{
    ulong hash = 1099511628211; // hash starts using FNV offset base value used in FNV-1 and FNV-1a hash

    unchecked // Allows values to overflow in C#, used to ensure the hash dosent create stack overflow errors.
    {
        foreach (char c in input)
        {
            hash ^= (hash << 13); // hash XOR (hash bitshift left 13 times)
                                  // used to mix the hash with itself after bitshifting
            hash *= 11400714819323198485; // hash multiplied by 2^64 * phi which is the golden ratio
                                          // used to scramble the value after previous operation

            hash ^= (hash >> 7); // hash XOR (hash bitshift right 7 times)
                                 //used to mix the hash with itself after bitshifting
            hash *= 6364136223846793005; // hash multiplied again using a constant with a good bit spread (given by chatGBT)
                                         // used to scramble the value after previous operation

            hash += c; // adding input character
        }
    }

    return hash.ToString("X16"); // hash converted to hexadecimal string limited to 16 positions.
}

//code for trying the algorithm, to exit just close console.
bool cont = true;
do
{
    Console.WriteLine("what is your input string\n");
    string start = Console.ReadLine();

    string hashed = ComputeHash(start);

    Console.WriteLine($"the hash for {start} is {hashed}");

} while (cont);