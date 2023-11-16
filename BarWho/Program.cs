using KassenmanagementLibrary;

Product produkt = new Product();
produkt.Name = "apfel";
produkt.Articlenumber = 1;
produkt.Quantityarticle = true;
produkt.Price =12.0;

Product produkt2 = new Product();
produkt.Name = "birne";
produkt.Articlenumber = 2;
produkt.Quantityarticle = true;
produkt.Price = 14.0;

ShoppingBasket basket = new ShoppingBasket();

Dictionary<Product,uint>  products = new Dictionary<Product,uint>();
products.Add(produkt, 1);
products.Add(produkt2,2);


Console.WriteLine($"erster preis { produkt.Price}");
Console.WriteLine($"zweiter preis {produkt2.Price}");

Console.ReadKey();


