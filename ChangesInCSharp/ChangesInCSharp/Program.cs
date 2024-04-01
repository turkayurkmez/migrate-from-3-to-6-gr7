
#region global usings, implicitly using ve file-scoped namespace


using ChangesInCSharp;
using ChangesInCSharp.Services;
using System.Runtime.CompilerServices;

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

#region Struct İyileştirmeleri
CustomerListResponseDto dto1 = new CustomerListResponseDto(Id: 1, Name: "Arçelik", Country: "Türkiye");
CustomerListResponseDto dto2 = new CustomerListResponseDto(Id: 1, Name: "Arçelik", Country: "Finlandiya");

List<CustomerListResponseDto> collection = new() { dto1, dto2 };

collection.Contains(dto1);
var count = collection.Count(d => d == dto1);


Console.WriteLine($"Karşılaştırma 1 x==y : {dto1 == dto2} ");
Console.WriteLine($"Karşılaştırma 2 x.Equals(y) : {dto1.Equals(dto2)} ");
Console.WriteLine($"Karşılaştırma 3 x.GetHashCode()==y.GetHashCode() : {dto1.GetHashCode() == dto2.GetHashCode()} ");

Address address = new Address();
address.Name = "Çanakkale";

Address address1 = address;
address1.Name = "Eskişehir";

Console.WriteLine(address.Name);
Console.WriteLine(address1.Name);


#endregion
#region Karışık tanımlama ve tuple alternatif değişkenleri
int s1;
int s2;
(s1, s2) = (-16, 9);
(var s3, bool isOk) = (9.3, true);
(s1, bool isCancel) = (4, s1 > 2);



(int, int) bolmeIslemi(int a, int b)
{
    //var tuple = Tuple.Create(a / b, a % b);
    //return tuple;

    return (a / b, a % b);
}

(int bolum, int kalan) = bolmeIslemi(13, 4);
Console.WriteLine($"Bölüm sonucu: {bolum}, kalan: {kalan}");

#endregion

#region CallerArgumentException Attirbute'ü ve kullanımı!

void isValid(bool expression, [CallerArgumentExpression("expression")] string? message = null)
{
    if (!expression)
    {
        Console.WriteLine($" {message} ifadesi Olumsuz");
    }
    else
    {
        Console.WriteLine($"{message} ifadesi olumlu");
    }
}

isValid(5 > 3);
isValid(3 > 5);
var isCalculated = false;

isValid(isCalculated);
var name = "Türkay";
isValid(name.StartsWith("T"));

#endregion

//public record struct SonucVeKalan(int Sonuc, int Kalan);
object obj = new Customer { Name = "Türkay", Address = new CustomerAddress { City = "Eskişehir", Country = "Türkiye" } };

//if (obj is Customer)
//{
//    if (((Customer)obj).Address.City=="Eskişehir")
//    {

//    }
//}
#region Property matching Pattern
if (obj is Customer { Address.City: "Eskişehir" })
{
    var customer = (Customer)obj;
    Console.WriteLine(customer.Name);
}

#endregion