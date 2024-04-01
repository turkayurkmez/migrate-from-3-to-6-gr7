
#region global usings, implicitly using ve file-scoped namespace


void getHello() => Console.WriteLine("Metottan selam!");

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
getHello();

DataTable dataTable = new DataTable();

#endregion

#region Lambda ve anonim tiplerde "doğal" yetenek
//eski:
Func<int, bool> isEven = number => number % 2 == 0;
//yeni:
var isEvenAnonym = (int number) => number % 2 == 0;

IEnumerable<int> numbers = Enumerable.Range(1, 10);
numbers.Where(isEvenAnonym);
//var isOddAnonym = number => number % 2 == 1;...... anonim tipin anlaşılması parametre tipi mutlaka belirli olmalı.
Delegate isOddAnonym = (int number) => number % 2 == 1;

//eski:
Func<int> read = Console.Read;
Action<string> write = Console.Write;
//yeni
var read2 = Console.Read;
//var write2 = Console.Write -- Çalışmaz!;

//lambda expression'lara dönüş değeri belirtileviliyor:
var result = object (bool isCancelled) => isCancelled ? "iptal edildi" : -1;

#endregion

