using KassenmanagementLibrary;
using System.Collections.ObjectModel;

//Test ob alle klassen der KassenmanagerLibrary funktionieren.

Product product1 = new Product("Apfel", 1, 10.99, false, new List<CLIPVector> { new CLIPVector(new double[] { 1.0, 2.0, 3.0 }) });
Product product2 = new Product("Eistee", 2, 5.49, true, new List<CLIPVector> { new CLIPVector(new double[] { 4.0, 5.0, 6.0 }) });
Product product3 = new Product("klopapier", 3, 8.75, true, new List<CLIPVector> { new CLIPVector(new double[] { 7.0, 8.0, 9.0 }) });
Product product4 = new Product("Reis", 4, 12.50, true, new List<CLIPVector> { new CLIPVector(new double[] { 10.0, 11.0, 12.0 }) });
Product product5 = new Product("Batterien", 5, 6.99, true, new List<CLIPVector> { new CLIPVector(new double[] { 13.0, 14.0, 15.0 }) });
Product product6 = new Product("Banane", 6, 9.99, false, new List<CLIPVector> { new CLIPVector(new double[] { 16.0, 17.0, 18.0 }) });

// Füge die neuen Produkte zum Warenkorb hinzu



ShoppingBasket shoppingBasket = new ShoppingBasket();


// Füge Produkte zum Warenkorb hinzu
shoppingBasket.AddArticle(product1);
shoppingBasket.AddArticle(product2);
shoppingBasket.AddArticle(product3);
shoppingBasket.AddArticle(product4);
shoppingBasket.AddArticle(product5);
shoppingBasket.AddArticle(product6);
shoppingBasket.AddArticle(product2);

shoppingBasket.generateReciept();

List<Product> produkte = new List<Product>();
produkte.Add(product1);
produkte.Add(product2);



LineOfGoods lineOfGoodsInstance = LineOfGoods.Instance;
lineOfGoodsInstance.Add(product1);
lineOfGoodsInstance.Add(product2);

string filePath = "D:\\ProgProjekt\\Sortiment";
lineOfGoodsInstance.Safe(filePath);





Console.ReadKey();


