using KassenmanagementLibrary;

//Test ob alle klassen der KassenmanagerLibrary funktionieren.

Product product1 = new Product("Apfel", 1, 10.99, false, new List<CLIPVector> { new CLIPVector(new double[] { 1.0, 2.0, 3.0 }) });
Product product2 = new Product("Eistee", 2, 5.49, true, new List<CLIPVector> { new CLIPVector(new double[] { 4.0, 5.0, 6.0 }) });
Product product3 = new Product("klopapier", 3, 8.75, true, new List<CLIPVector> { new CLIPVector(new double[] { 7.0, 8.0, 9.0 }) });
Product product4 = new Product("Reis", 4, 12.50, true, new List<CLIPVector> { new CLIPVector(new double[] { 10.0, 11.0, 12.0 }) });
Product product5 = new Product("Batterien", 5, 6.99, true, new List<CLIPVector> { new CLIPVector(new double[] { 13.0, 14.0, 15.0 }) });
Product product6 = new Product("Banane", 6, 9.99, false, new List<CLIPVector> { new CLIPVector(new double[] { 16.0, 17.0, 18.0 }) });

// Füge die neuen Produkte zum Warenkorb hinzu


// Erstelle einen leeren Warenkorb
ShoppingBasket shoppingBasket = new ShoppingBasket(new Dictionary<Product, uint>());

// Füge Produkte zum Warenkorb hinzu
shoppingBasket.addArticle(product1, 2);
shoppingBasket.addArticle(product2, 3);
shoppingBasket.addArticle(product3, 1);
shoppingBasket.addArticle(product4, 2);
shoppingBasket.addArticle(product5, 2);
shoppingBasket.addArticle(product6, 3);


shoppingBasket.generateReciept(shoppingBasket);


Console.ReadKey();


