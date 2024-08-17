# BARWHO
## A Windows desktop application that scans products using image recognition and includes all the features of a point-of-sale system.

## Explanation:
This project is part of my third-semester module "Programmierprojekt" at HTW Berlin, and I worked on it with my colleagues **Can Schwabe, Shawn Seibt, and Ralf Raab**.
The aim of our project was to create free software that empowers shop owners worldwide to scan and sell their goods easily without having to rely on barcodes.
All products can be added to the database by taking a short video.

## How to use it:
When you start the program, you should see your laptop camera on the left side and the current shopping basket on the right side.

To add your first product, press the "Edit Line of Goods" button, and then in the pop-up window, click the "Add" button.
Now, you have to enter the name, article number, and price of your product and specify whether its price is calculated by weight or quantity.
**IMPORTANT:** Before you click the "Add" button, please hold your desired product in front of your laptop camera and click "Add Images to Product"!
Please hold your product in front of the camera until the text on the button says "Successfully added!"
Now you can finally click the "Add" button to add your product to the line of goods.

If you want to modify a product in your line of goods, press the "Edit Line of Goods" button and then in the pop-up window, click the "Edit" button.
You will follow the same steps as if you were creating a new product to edit it.

If you want to delete a product in your line of goods, press the "Edit Line of Goods" button, select your desired product in the list with a left click, and then press the "Delete" button.

If you want to scan a product, press the spacebar on your keyboard and wait for one second. Hold your product in view of your camera so that you can see it on your screen.
If a product is detected successfully, it will automatically be added to the shopping basket on the right, and a beep sound will play.
If the program has too little certainty about which product it could be from your line of goods, no product will be added, and you will hear a negative sound.

If somehow a product isn’t recognized by the program, you can add it manually by clicking the "Add Manually" button, selecting your desired item with a left click, and adding it to the shopping basket.
You can edit all products in the shopping basket by clicking on them and using the "+" and "-" buttons in the lower right corner.
Products that are defined by count will automatically change.
When you select a product whose price is calculated by weight, a pop-up window will open, and you can enter the new weight.
If you click the shopping basket icon in the upper right corner, all products in the shopping basket will be deleted.

To complete the transaction, press the "Pay" button.
There, you enter the amount of money paid by the customer and receive the change amount.
After clicking "Finish Transaction," all products in the shopping basket will be automatically deleted.

## Installation instructions for users

**1. To use the CLIP API, follow these instructions:** *(source: https://gitlab.rz.htw-berlin.de/kiwerkstatt-services/zeroshotdemo)*

**For the first time:**
1. Install Python **3.8 64-bit** from https://www.python.org/downloads/release/python-380/ **(Check "Add to PATH" during installation)**
2. Open the Command Prompt and verify installation with: **pip --version**
3. Create an empty folder for the repository, e.g., **C:\Zeroshot**
4. Navigate to this folder in the Command Prompt with: **cd C:\Zeroshot**
5. Clone the repository into this directory with: **git clone https://gitlab.rz.htw-berlin.de/kiwerkstatt-services/zeroshotdemo.git**
7. Enter the repository with: **cd zeroshotdemo**
8. Upgrade pip with: **python -m pip install --upgrade pip**
9. Now install dependencies with: **pip install -r requirements.txt**
10. Start the API connection with: **python ./run.py**
11. Allow the request


**For reuse:**
1. cd C:\Zeroshot (example)
2. cd zeroshotdemo
3. python ./run.py
   
**2. Installation of BarWho:**
1. Click on **"Code"** at the top and copy the **HTTPS link** to this repository.
2. Install Visual Studio 2022 and click **"Clone a repository"** in the start window, then paste the HTTPS link.
3. Click on **"Configure startup projects..."** next to the green arrow in the top bar, and select **GUI** as the **single startup project**.
   It should now show only GUI next to the green arrow.
4. Ensure that the connection to the CLIP API is online before starting the project.
5. Press the green arrow next to GUI to start the program.
