# BARWHO
## A Windows desktop application that scans products using image recognition and includes all the features of a point-of-sale system.

## Explanation:
This project is part of my third semester module "Programmierprojekt" at HTW Berlin and i worked on it whit my collegues **Can Schwabe, Shawn Seibt and Ralf Raab**.
The Aim of our project was to create a free software that empowers shopowners all over the world to scan and sell their goods easily without having to worry about a barcodes.
All products can be added to the database via taking a short video.

## How to use it:
When you start the programm you should see your laptop camera on the left side and on the right side the current shopping basket.

To add your first product, press the "edit line of goods" button and then in the pop-up-window the "Add"-button.
Now you have to enter the name, article number and  price of your product and if its price is calculated via weight or quantity. 
**IMPORTANT**: Before you click the "Add"-button, please hold your desired product in front of your laptop Camera and click "Add Images to Product"!
Please hold your product in front of the camera till the text in the button says "Succesfully added!"!
Now you can finally click the "Add"-button to add your product to the line of goods.

If you want to change a product in your line of goods you have to press the "edit line of goods" button and then in the pop-up-window the "Edit"-button.
You have to do basically the same things as if you would create a new product for editing it.

If you want to delete a product in your line of goods you have to press the "edit line of goods" button, select your desired product in the list with a left click and then press the "Delete"-Button.

If you want to scan a product, you have to press space on your keyboard and wait for one second. Hold your product in the view of your camera, so that you can see it on your screen. If a product was detected succesfully, it will automatically be added to the shopping basket on the right and make a piep-sound. If the programm has to little certainty which product from our line of goods it could be, no product will be added and you will hear a negative sound.

If somehow a product isnt recognized by the programme you can add it manually by clicking on the "Add manually"-button. 





## Installation instructions for users

1. Für Verwendung der CLIP-API folge den Anweisungen von diesem Repo: https://gitlab.rz.htw-berlin.de/kiwerkstatt-services/zeroshotdemo

**Beim ersten Mal:**
-> Python **3.8 64bit** installieren auf https://www.python.org/downloads/release/python-380/  **(Klicken Sie "Add to PATH" beim installieren)**
-> Öffne das Programm Eingabeaufforderung und überprüfe mit: pip --version
-> Eigenes Verzeichnes erstellen (zum Beispiel: cd C:\Zeroshot)
-> Repository in dieses Verzeichnis klonen mit: git clone https://gitlab.rz.htw-berlin.de/kiwerkstatt-services/zeroshotdemo.git
-> In dieses Repository reingehen mit: cd zeroshotdemo
-> python -m pip install --upgrade pip
-> Jetzt Abhängigkeiten installieren mit: pip install -r requirements.txt
-> Verbindung zur API starten mit: python ./run.py
-> anfrage zulassen

**Beim Wiederverwenden:**
cd C:\Zeroshot
cd zeroshotdemo
python ./run.py
