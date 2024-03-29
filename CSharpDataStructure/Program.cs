
/*
    1. All Data Structures are Generic Collections [using System.Collections.Generic].
    2. we must iterate on them (by using foreach) to display their values.
 */

#region Basic C# Data Structure

//========================== Strings: are collections of characters, and are immutable (غير قابل للتغيير) ==========================
using System.Collections.Specialized;
using System.Text;

string s1 = "Hello World ";

char[] c1 = new char[] { 'f', 'i', 'z', 'z', 'y', ' ', 'b', 'u', 'z', 'z' };
string s2 = new string(c1);

s1 += s2;
Console.WriteLine("string1: " + s1); // Hello World fizzy buzz

s2 = s2.ToUpper();
Console.WriteLine("string2: " + s2); // FIZZY BUZZ
Console.WriteLine("string1: " + s1); // Hello World fizzy buzz (immutable)


////========================== Be careful with string references ==========================
string s3 = "Hello ";
string s4 = s3;
s3 += "World";
Console.WriteLine("string3: " + s3); // Hello World (it creates a new string)
Console.WriteLine("string4: " + s4); // Hello (it will not change, because it's immutable)


//========================== Arrays: are contigous storage (تخزين متجاور) of the same variable type, they are also implicitly typed (يمكن تحديد نوع المتغير من خلال المدخلات ضمنيا) ==========================
int[] sum = new int[5] { 1, 2, 3, 4, 5 };
int[] sum2 = { 1, 2, 3, 4, 5 };


var sum3 = new[] { "ali", "ahmed" }; // implicitly typed to string[]
object[] objects = { "ali", 12, true }; // multi type array


//========================== Tuples: are lightweight data structures, that are used to group multiple data elements together (without needing a class) ==========================
(string, int, bool) t1 = ("ali", 134, false);
Console.WriteLine("tuple1: " + t1);
Console.WriteLine($"{t1.Item1} , {t1.Item2}, {t1.Item3}");

(string s, int i, bool b) t2 = ("ahmed", 287, true);
Console.WriteLine("tuple2: " + t2);
Console.WriteLine($"{t2.s}, {t2.i}, {t2.b}");

var t3 = (s:"mustafa", i: 456, b: false);
Console.WriteLine("tuple3: " + t3);
Console.WriteLine($"{t3.s}, {t3.i}, {t3.b}");
#endregion

#region Introduction to C# Data Collections

// List:                works with items in an array-like structure, accessed by index.
// LinkedList:          keeps track of items using forward and backward references.
// Stack:               operates on data using a last-in first-out (LIFO) method.
// Queue:               operates on data using a first-in first-out (FIFO) method.
// Dictionary:          associates a unique key with a given value or object.

// ListDictionary:      implements a Dictionary using a singly LinkedList [it's fast for small data sets (<100 or so)].
// HybridDictionary:    starts off as a ListDictionary, then switches to a Dictionary when the data set gets larger.
// OrderedDictionary:   maintains the order in which items are added to it.

// StringCollection:    a specialized collection for operating on strings.
// StringBuilder:       used to compile and operate on multiple strings.

#endregion

#region How to select the appropriate data structure

/*
 
 -------------------------------------------------------------------------------------------------------------------------
 |                                                  |    List   |   LinkedList  |   Stack   |     Queue     | Dictionary |
 |------------------------------------------------------------------------------------------------------------------------
 | good for random access to data, fast retrieval   |    true   |               |           |               |    true    |
 | -----------------------------------------------------------------------------------------------------------------------
 | good for sequential access to data               |           |    true       |   true    |     true      |            |    
 | -----------------------------------------------------------------------------------------------------------------------
 | faster adding and removing of data               |           |    true       |   true    |     true      |            |
 | -----------------------------------------------------------------------------------------------------------------------
 | items intended to be kept in memory              |    true   |    true       |           |               |    true    |
 | -----------------------------------------------------------------------------------------------------------------------
 | items intended to be discarded after processing  |           |               |   true    |     true      |            |
 |------------------------------------------------------------------------------------------------------------------------
 | needs contiguous memory to store data            |    true   |               |   true    |     true      |    true    |
 |------------------------------------------------------------------------------------------------------------------------
 | specific order of data access (LIFO,FIFO)        |           |               |   true    |     true      |            |
 -------------------------------------------------------------------------------------------------------------------------

 */
#endregion

#region Basic List Operations (Read, Insert, Remove)

//================= Define some strings to add to the list =================
string[] writers = new string[] { 
    "Al-Rafa'i",
    "Al-Manfalouti", 
    "Hafez Ibrahim", 
    "Ahmed Shawqi", 
    "Abbas El-Aqqad", 
    "Taha Hussein", 
    "Nagib Mahfouz"
};

//================= Create the List =================
List<string> writersList = new List<string>(10); // capacity = 10 , count = 0

//================= Add elements to the list (Insert) =================
writersList.AddRange(writers); // count = 7
writersList.Add("Mostafa Mahmoud"); // count = 8    // Add(),AddRange(): insert at the end of the list

writersList.InsertRange(2, new string[]{ "Elia Abu Madi", "asd"});
writersList.Insert(1,"Ma'rouf Al-Rasafy"); // Insert(),InsertRange(): insert at any index of the list

//================= Count & Capacity of List =================
Console.WriteLine("Count of writersList: "+ writersList.Count); // 8
Console.WriteLine("Capacity of writersList: "+ writersList.Capacity); // 10

//================= Enumerate (سرد/عد) the items in the list with a foreach loop =================
foreach(string writer in writersList)
{
    Console.WriteLine(writer);
}

//================= Access any item in the List (Read) =================
Console.WriteLine("Access writer in index 4: " + writersList[4]);

//================= Remove elements from the list (Delete) =================
writersList.Remove("Taha Hussein"); // it will remove "Taha Hussein"
writersList.RemoveRange(4,2); // it will remove "Abbas El-Aqqad", "Nagib Mahfouz"
writersList.RemoveAt(4); // it will remove "Mostafa Mahmoud"
foreach (string writer in writersList)
{
    Console.WriteLine(writer);
}

//================= Sort and Reverse the list =================
writersList.Sort();
writersList.Reverse();
foreach (string writer in writersList)
{
    Console.WriteLine(writer);
}

#endregion

#region Searching List Content (Search)

//================= Contains(): Determine if a list contains a given item =================
Console.WriteLine(writersList.Contains("Mostafa Mahmoud")); //false

//================= Exists(): gives a more customizable way to search by using a predicate function to examine each element in the list  =================
Console.WriteLine(writersList.Exists(w => w.Length > 10)); // true

//================= Find(),FindAll(): Search for items themselves =================
string? item = "";
item = writersList.Find(w => w.StartsWith("A")); // if there are many items start with letter "A", Find() will take the first item only
Console.WriteLine(item); // Al-Rafa'i

List<string>? items = new List<string>();
items = writersList.FindAll(w => w.StartsWith("A"));// returns a list of elements
foreach(string value in items)
{
    Console.WriteLine(value);
}

//================= TrueForAll(): check if a given condition is true for all elements in the list =================
Console.WriteLine(writersList.TrueForAll(w=>w.Length>10)); //false

#endregion

#region LinkedList
// Note: elements in LinkedList are accessed sequentially (بالتعاقب/بالتتابع) instead of directly using index as in List.
// Note: (Insert) and (Delete) are very fast in LinkedList.

//=================== Define some strings that represent song names ===================
string[] songs = {
    "shout", "satisfaction", "help!", "stairway to heaven", 
    "come sail away", "all night long", "right here right now"
};

//=================== create a LinkedList ===================
LinkedList<string> songsList = new LinkedList<string>(songs);

//=================== items can be added in the front or the back of the LinkedList (Insert) ===================
songsList.AddFirst("africa"); // item is added in the beginning of the list
songsList.AddLast("the twist"); // item as added at the end of the list

//=================== like other collections, a LinkedList can be iterated (using foreach) ===================
foreach (var song in songsList)
{
    Console.WriteLine(song);
}


//=================== "First" and "Last" properties return LinkedListNode<T>? ===================
LinkedListNode<string>? firstSong = songsList.First;
LinkedListNode<string>? lastSong = songsList.Last;

Console.WriteLine("firstSong: "+ firstSong.Value);
Console.WriteLine("lastSong: " + lastSong.Value);

//=================== items can be added or removed related to a LinkedList item (Insert) ===================
songsList.AddAfter(songsList.First, "here comes the sun");
songsList.AddBefore(songsList.Last, "waka waka");

foreach (var song in songsList)
{
    Console.WriteLine(song);
}

//=================== (Search) for items in the LinkedList using Contains() and Find() ===================
Console.WriteLine(songsList.Contains("here comes the sun")); //true
Console.WriteLine(songsList.Find("help!")); //returns LinkedListNode<T>
Console.WriteLine(songsList.Find("help!").Value); // help!


//=================== LinkedList items can be traversed (يمكن اجتيازها) with "Next" and "Previous" properties ===================
Console.WriteLine(songsList.First.Next.Value); // returns the value of the item following to the first item
Console.WriteLine(songsList.Last.Previous.Value); // returns the value of the item previous to the last item


//=================== remove items from a LinkedList (Delete) ===================
songsList.RemoveFirst(); // removes the first item
songsList.RemoveLast(); // removes the last item
songsList.Remove("come sail away"); // removes a given item
songsList.Remove(songsList.Last); // overload which takes a LinkedListNode<T>

foreach (var song in songsList)
{
    Console.WriteLine(song);
}


//=================== get items from a LinkedList (Read) ===================
Console.WriteLine(songsList.ElementAtOrDefault(10)); //default: null
Console.WriteLine(songsList.ElementAt(2));

#endregion

#region List VS LinkedList


/*
 
 --------------------------------------------------------------------------------
 |                                                  |    List   |   LinkedList  |
 |-------------------------------------------------------------------------------
 | looking up items (Read)                          |    O(1)   |      O(N)     |
 | ------------------------------------------------------------------------------
 | adding elements at the beginning (Insert)        |    O(N)   |      O(1)     |   
 | ------------------------------------------------------------------------------
 | adding elements at the end (Insert)              |    O(1)   |      O(1)     |
 | ------------------------------------------------------------------------------
 | adding elements in the middle (Insert)           |    O(N)   |      O(N)     |
 | ------------------------------------------------------------------------------
 | removing elements at the beginning (Delete)      |    O(N)   |      O(1)     |   
 | ----------------------------------------------------------------------------
 | removing elements at the end (Delete)            |    O(1)   |      O(1)     |
 | ----------------------------------------------------------------------------
 | removing elements in the middle (Delete)         |    O(N)   |      O(N)     |
 --------------------------------------------------------------------------------

 */

#endregion

#region Challenge: Shopping List
//============================== we want some methods in a class to [Add,Remove,Count,Print] a list of items ==============================

//ShoppingList listOfShopping = new ShoppingList();
//listOfShopping.AddItem("mobile", 15000, 3);
//listOfShopping.AddItem("shirt", 500, 2);
//listOfShopping.AddItem("shoes", 800, 4);
//listOfShopping.PrintList();
//Console.WriteLine("items count: " + listOfShopping.CountItems());


//listOfShopping.RemoveItem("shoes");
//listOfShopping.RemoveItem("mobile");
//listOfShopping.PrintList();
//Console.WriteLine("items count: " + listOfShopping.CountItems());

//public class ShoppingItem
//{
//    public string ItemName { get; set; }
//    public double Price { get; set; }
//    public int Quantity { get; set; }
//}

//public class ShoppingList
//{
    
//    List<ShoppingItem> shoppingItems = new List<ShoppingItem>();

//    public void AddItem(string itemName, double price, int quantity)
//    {
//        shoppingItems.Add(new ShoppingItem(){
//             ItemName = itemName, 
//             Price = price, 
//             Quantity = quantity 
//        });
//    }

//    public void RemoveItem(string itemName)
//    {
//        ShoppingItem foundItem = null;

//        foreach (var item in shoppingItems)
//        {
//            if(item.ItemName == itemName)
//            {
//                foundItem = item;
//                break;
//            }
//        }

//        if(foundItem != null)
//        {
//            if (foundItem.Quantity > 1)
//                foundItem.Quantity--;
//            else
//                shoppingItems.Remove(foundItem);
//        }


//    }

//    public int CountItems()
//    {
//        int count = 0;
//        foreach (var item in shoppingItems)
//        {
//            count += item.Quantity;
//        }
//        return count;
//    }

//    public void PrintList()
//    {
//        foreach (var item in shoppingItems)
//        {
//            Console.WriteLine($"item: {item.ItemName} | price: {item.Price} | quantity: {item.Quantity}");
//        }
//    }
//}

#endregion

#region Stack [Last In First Out (LIFO)]

//===================== create an empty stack =====================
Stack<string> levels = new Stack<string>();


//===================== Push(): is used to add elements at the top/end of the stack (Insert) =====================
levels.Push("one");
levels.Push("two");
levels.Push("three");
levels.Push("four");


//===================== Pop(): is used to remove elements from the top/end of the stack (Delete) =====================
levels.Pop();


//===================== Clear(): is used to remove all elements of the stack (Delete) =====================
//levels.Clear();


//===================== Peek(): is used to know the element at the top/end of the stack =====================
Console.WriteLine($"Levels Peek: {levels.Peek()}");


//===================== "Count" property =====================
Console.WriteLine($"Levels Count: {levels.Count}");


//===================== Stacks can be enumerated in place without changing the content =====================
foreach (var level in levels)
{
    Console.WriteLine(level);
}


//===================== search for an element in the stack (Search) =====================
Console.WriteLine(levels.Contains("three")); //true


//===================== get a value of an index in the stack (Read) =====================
Console.WriteLine(levels.ElementAt(0)); // it will get item at index 0 | algorithm: O(1)

#endregion

#region Queue [First In First Out (FIFO)]

//===================== create an empty stack =====================
Queue<string> departments = new Queue<string>();


//===================== Enqueue(): is used to add elements at the end of the queue (Insert) =====================
departments.Enqueue("one");
departments.Enqueue("two");
departments.Enqueue("three");
departments.Enqueue("four");


//===================== Dequeue(): is used to remove elements from the start of the queue (Delete) =====================
departments.Dequeue();


//===================== Clear(): is used to remove all elements of the queue (Delete) =====================
//departments.Clear();


//===================== Peek(): is used to know the element at the start of the queue =====================
Console.WriteLine($"departments Peek: {departments.Peek()}");


//===================== "Count" property =====================
Console.WriteLine($"departments Count: {departments.Count}");


//===================== Queues can be enumerated in place without changing the content =====================
foreach (var department in departments)
{
    Console.WriteLine(department);
}


//===================== search for an element in the queue (Search) =====================
Console.WriteLine(departments.Contains("three")); //true


//===================== get a value of an index in the queue (Read) =====================
Console.WriteLine(departments.ElementAt(0)); // it will get item at index 0 | algorithm: O(1)


#endregion

#region Dictionary

//======================= Dictionaries map Keys to Values. Keys must be unique =======================
Dictionary<string, string> fileTypes = new Dictionary<string, string>();


//======================= Add(): add some keys and values to Dictionary (Insert) =======================
fileTypes.Add(".pdf", "Pdf file");
fileTypes.Add(".xlsx", "Excel file");
fileTypes.Add(".txt", "Text file");
fileTypes.Add(".html", "HTML document");


//======================= adding existing key will throw exception =======================
//fileTypes.Add(".html", "HTML file");


//======================= TryAdd(): checks if the key can be used or not because it is already used before =======================
Console.WriteLine(fileTypes.TryAdd(".html", "HTML file")); // false


//===================== "Count" property =====================
Console.WriteLine($"fileTypes Count: {fileTypes.Count}");


//===================== we can access any element in the dictionary throw its key/index like arrays (Read) =====================
Console.WriteLine(fileTypes[".html"]); // "HTML document"

fileTypes[".html"] = "HTML file";
Console.WriteLine(fileTypes[".html"]); // "HTML file"



//===================== ContainsKey(),ContainsValue(): checks if the key/value exists (Search) =====================
Console.WriteLine(fileTypes.ContainsKey(".csv")); // false
Console.WriteLine(fileTypes.ContainsValue("Excel file")); // true



//======================= Remove(): removes the value of a certain key (Delete) =======================
fileTypes.Remove(".html");
foreach (var file in fileTypes)
{
    Console.WriteLine($"Key: {file.Key} | Value: {file.Value}");
}


#endregion

#region Challenge: Balance The Statement
//============================== we want to make a method to check if the code syntax is written correctly or not ==============================

string[] testStatements =
{
    "print('hello world')", // correct
    "if a(b[x]) == b(a[x])", // correct
    "function t(x) { print('t(x)') }", // correct
    "print 'hello world')", // wrong
    "f(x) = g(x[2)", //wrong
    "}"

};

foreach (var testStmt in testStatements)
{
    bool result = CheckBalanced(testStmt);
    Console.WriteLine($"Statement '{testStmt}' {(result ? "is" : "is not")} balanced.");
}

static bool CheckBalanced(string stmt)
{
    Stack<char> tempStack = new Stack<char>();

    foreach (var c in stmt)
    {
        if (c == '{' || c == '[' || c == '(')
                 tempStack.Push(c);

        if (c == '}' || c == ']' || c == ')')
        {
            if (tempStack.Count == 0)
                return false;

            char testChar = tempStack.Pop();
            if (c == '}' && testChar != '{')
                return false;
            if (c == ']' && testChar != '[')
                return false;
            if (c == ')' && testChar != '(')
                return false;
        }
    }

    // if there are characters left in the tempStack, we are still unbalanced
    if (tempStack.Count > 0)
        return false;

    return true;
}


#endregion

#region SortedDictionary

//=========================== it sorts the valuePairs by their keys  ===========================

SortedDictionary<int, string> valuePairs = new SortedDictionary<int, string>();

valuePairs.Add(2, "ahmed");
valuePairs.Add(1, "mustafa");
valuePairs.Add(4, "shadi");
valuePairs.Add(3, "ali");

foreach (var val in valuePairs)
{
    Console.WriteLine($"key: {val.Key} | value: {val.Value}");
}


#endregion

#region StringCollection

//============================= define an initial set of strings =============================
string[] colors = { "red", "blue", "yellow", "green", "black", "white" };


//============================= create the string collection =============================
StringCollection colorsCollection = new StringCollection();


//============================= (Insert) =============================
colorsCollection.AddRange(colors); // add at the end 
colorsCollection.Add("purple"); // add at the end
colorsCollection.Insert(0,"brown"); // add at any index (start,middle,end)


//============================= Count =============================
Console.WriteLine(colorsCollection.Count);

//============================= foreach =============================
foreach (var color in colorsCollection)
{
    Console.WriteLine($"color: {color}");
}


//============================= (Read) =============================
Console.WriteLine(colorsCollection[3]);


//============================= (Search) =============================
Console.WriteLine(colorsCollection.Contains("red")); //true
Console.WriteLine(colorsCollection.IndexOf("red")); //1


//============================= (Delete) =============================
colorsCollection.Remove("purple");
colorsCollection.RemoveAt(3); //removes the item at index 3
                              //colorsCollection.Clear(); //removes the entire collection


#endregion

#region StringBuilder
//==================== creates a string builder that expects to hold 50 characters, initialize the StringBuilder with 'ABC' ====================
StringBuilder stringbuilt = new StringBuilder("ABC", 50); // value: "ABC" | capacity: 50
Console.WriteLine(stringbuilt.Capacity); //50
Console.WriteLine(stringbuilt.MaxCapacity); //2,147,483,647

//==================== Append(): Append three chars ('D', 'E', and 'F') to the end of the StringBuilder ====================
stringbuilt.Append(new char[]{ 'D', 'E', 'F'});
Console.WriteLine(stringbuilt);


//==================== AppendFormat(): Append a format string to the end of the StringBuilder ====================
stringbuilt.AppendFormat("GHI{0}{1}","J","K");
Console.WriteLine(stringbuilt);
Console.WriteLine(stringbuilt.ToString());
Console.WriteLine(stringbuilt.Length);


//==================== AppendJoin(): add an array of strings with a separator character ====================
stringbuilt.AppendJoin("-",new char[] {'L','M','N','O'});
Console.WriteLine(stringbuilt);


//==================== (Insert) a string at the beginning of StringBuilder ====================
stringbuilt.Insert(0, "Alphabet: ");
Console.WriteLine(stringbuilt);


//==================== Replace(): Replace existing values with new ones ====================
stringbuilt.Replace("O", "Z");
Console.WriteLine(stringbuilt);


#endregion

#region Challenge: Strings
string[] gettysburgAddress =
{
    "four score and seven years ago our",
    "fathers brought fourth on this continent",
    "a new nation conceived in liberty",
    "and dedicated to the proposition",
    "that all men are created equal"
};


//Requirements:

static void PrintString(string theString)
{
    // split the string on space character boundary
    string[] wordArray = theString.Split(" ");

    
    // count the total number of words
    StringCollection wordCollection = new StringCollection();
    wordCollection.AddRange(wordArray);
    Console.WriteLine($"The count of words: {wordCollection.Count}");


    // find the longest word
    int maxLength = 0;
    string longestWord = "";
    foreach (var word in wordCollection)
    {
        if(word.Length > maxLength)
        {
            longestWord = word;
            maxLength = word.Length;
        }
    }
    Console.WriteLine($"The longest word: {longestWord}");


    // build the word count data 
    Dictionary<string, int> wordDict = new Dictionary<string, int>();

    foreach (var word in wordCollection)
    {
        string key = word.ToLower();
        if (wordDict.ContainsKey(key))
            wordDict[key]++;
        else
            wordDict.Add(key, 1);
    }


    // print out the word count data 
    foreach (var key in wordDict.Keys)
    {
        Console.WriteLine($"The word: {key}, count: {wordDict[key]}");
    }

};


// convert the string array into a string and pass it to the PrintString() function
StringBuilder sb = new StringBuilder();
sb.AppendJoin(" ", gettysburgAddress);
string theText = sb.ToString();

PrintString(theText);

#endregion
