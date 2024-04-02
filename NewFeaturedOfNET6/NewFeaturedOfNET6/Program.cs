// See https://aka.ms/new-console-template for more information
using NewFeaturedOfNET6;
using System.Text;
using System.Text.Json;

Console.WriteLine("Merhaba, World!");
/*
 * .NET 6.0, öncekilerden belirgin bir biçimde daha hızlıdır. Bunun sebebi de Dynamic PGO (Profile-Guided Optimization) 'dur
 * 
 * PGO'nun nasıl çalıştığına bakma için: https://gist.github.com/EgorBo/dc181796683da3d905a5295bfd3dd95b
 *
 */

#region JsonSerializer, artık IAsyncEnumerable interface'i ile çalışabiliyor

async IAsyncEnumerable<int> Show(int maxNumber)
{
    for (int i = 0; i < maxNumber; i++)
    {
        yield return i;
    }
}

using var stream = Console.OpenStandardOutput();
var data = new { Values = Show(9) };
await JsonSerializer.SerializeAsync(stream, data);

Console.WriteLine();
Console.WriteLine("-------------------------------");
Console.WriteLine("  Deserialize ediliyor ");

var readableStream = new MemoryStream(Encoding.UTF8.GetBytes("[1,2,3,4,5,6]"));
await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<int>(readableStream))
{
    Console.Write(item.ToString() + " ");
}
Console.WriteLine();


#endregion

#region LINQ yenilikleri

#region yeni fonksiyon: TryGetNonEnumeratedCount()
var collection = Enumerable.Range(1, 15);
var totalCount = collection.Count(x => x % 3 == 0);
var countInCollection = collection.TryGetNonEnumeratedCount(out int count) ? count : 0;
Console.WriteLine(countInCollection);
Console.WriteLine(totalCount);
#endregion

#region ...By ile biten LINQ fonksiyonları
var customers = new CustomerService().GetCustomers();
var maxBudget = customers.Max(c => c.Budget);
var customer = customers.FirstOrDefault(c => c.Budget == maxBudget);


var bigCustomer = customers.MaxBy(c => c.Budget);
Console.WriteLine(bigCustomer.Name);

Console.WriteLine();
Console.WriteLine("***********");
Console.WriteLine("Çalışılan ülkeler:");
var countries = customers.DistinctBy(c => c.Country);
countries.ToList().ForEach(cust => Console.WriteLine(cust.Country));

#endregion

#region Chunks
var chunks = collection.Chunk(size: 4);
chunks.ToList().ForEach(item => Console.WriteLine($"[{string.Join(",", item)}]"));
#endregion

#region Index ve Range objeleri .NET'de!
var number = collection.ElementAt(^1);
Console.WriteLine($"ilk eleman: {collection.ElementAt(0)} son eleman ise {number} ");
Console.WriteLine($"ilk üç eleman: {string.Join(",", collection.Take(0..3))}");
Console.WriteLine($"6. elemandan son elemana: {string.Join(",", collection.Take(6..))}");
Console.WriteLine($"Son 4 eleman: {string.Join(",", collection.Take(^4..))}");



#endregion
#region Artık kendi defaultunuzu yazabilirsiniz:
var firstOrNegative = collection.FirstOrDefault(x => x > 15, -1);
var singleOrNegative = collection.SingleOrDefault(x => x > 15, -1);




#endregion
var customer2 = new Customer();
customer2.SubscriptionDate = new DateOnly(2024, 4, 15);
Console.WriteLine(customer2.SubscriptionDate.DayOfYear);

#endregion