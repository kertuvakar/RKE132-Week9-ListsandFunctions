
string folderPath = @"C:\Users\Kasutaja\Desktop\Õppematerjalid\2. kursus 2. semester kevad\Programmeerimise algkursus\9. nädal";
string fileName = "shoppingList.txt";
string filePath = Path.Combine(folderPath, fileName);
//att võimaldab ignoreerida kaldkriipse, mis on programmis reserveeritud sümbolitele.
List<string> myShoppingList = new List<string>();

if (File.Exists(filePath))
{
    myShoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myShoppingList);
    ShowItemsFromList(myShoppingList);
}
else
{
    File.Create(filePath).Close();//kui luua fail eraldi kuskil blokis, siis peab selle faili kinni panema.
    //kui fail on jäänud ühes protsessis lahti, siis teises protsessis sinna andmeid lisada ei saa.
    Console.WriteLine($"File {fileName} has been created");
    myShoppingList=GetItemsFromUser();
    File.WriteAllLines(filePath , myShoppingList);
}



static List <string> GetItemsFromUser() //soovime tagastada vahemälusse nimekirja
{
List <string> userList = new List<string>();

    while (true)
    {
        Console.WriteLine("Add an item (add)/ Exit (exit):");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter and item:");
            string userItem = Console.ReadLine();
            userList.Add(userItem);
        }
        else 
        {
            Console.WriteLine("Bye!");
            break;
        }

    }
    return userList;//kanna andmed tagasi vahemällu, et saaks hiljem nende andmetega tööd teha
}

static void ShowItemsFromList(List <string> someList)
{ 
    Console.Clear();

    int listLength = someList.Count;
    Console.WriteLine($"You have added {listLength} items to your shopping list.");

    int i = 1;//Kõik väärtused, mis tekivad foreach bloki raames, kõik väärtused toimivad ainult bloki sees. KUi
    //int i oleks defineeritud foreach sees, tekiks int i iga kord uuesti foreach vältel.
    foreach (string item in someList)//ma ei taha elemente muuta vaid lihtsalt kuvada. Saab kasutada foreach
    {
        Console.WriteLine($"{i}. {item}");
    i++;
    }
}