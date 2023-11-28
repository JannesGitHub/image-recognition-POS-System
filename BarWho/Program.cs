using KassenmanagementLibrary;
using System.Collections.ObjectModel;

//Test ob alle klassen der KassenmanagerLibrary funktionieren.

Product product1 = new Product("apple", 1, 10.99, false, new List<CLIPVector> { new CLIPVector(new double[] { 1.0, 2.0, 3.0 }) });
Product product2 = new Product("Tea", 2, 5.49, true, new List<CLIPVector> { new CLIPVector(new double[] { 4.0, 5.0, 6.0 }) });
Product product3 = new Product("klopapier", 3, 8.75, true, new List<CLIPVector> { new CLIPVector(new double[] { 7.0, 8.0, 9.0 }) });
Product product4 = new Product("Reis", 4, 12.50, true, new List<CLIPVector> { new CLIPVector(new double[] { 10.0, 11.0, 12.0 }) });
Product product5 = new Product("Batterien", 5, 6.99, true, new List<CLIPVector> { new CLIPVector(new double[] { 13.0, 14.0, 15.0 }) });
Product product6 = new Product("Banane", 6, 9.99, false, new List<CLIPVector> { new CLIPVector(new double[] { 16.0, 17.0, 18.0 }) });
Product product7 = new Product("Tea", 2, 5.49, true, new List<CLIPVector> { new CLIPVector(new double[] { 4.0, 5.0, 6.0 }) });

// Füge die neuen Produkte zum Warenkorb hinzu


ObservableCollection<Article> liste = new ObservableCollection<Article>();

// Erstelle einen leeren Warenkorb
ShoppingBasket shoppingBasket = new ShoppingBasket(liste);



// Füge Produkte zum Warenkorb hinzu5
shoppingBasket.AddArticle(product1);
shoppingBasket.AddArticle(product2);
shoppingBasket.AddArticle(product3);
shoppingBasket.AddArticle(product4);
shoppingBasket.AddArticle(product5);
shoppingBasket.AddArticle(product6);
shoppingBasket.AddArticle(product2);


shoppingBasket.generateReciept(shoppingBasket);


Console.ReadKey();


