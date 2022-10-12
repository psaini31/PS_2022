using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

// open chrome browser
IWebDriver driver = new ChromeDriver();
//navigate to Turnup portal
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

//maximize the window
driver.Manage().Window.Maximize();



//LOGIN 

//Identify the username textbox and enter valid username
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");


//Identify password textbox and enter valid password
IWebElement passwordtextbox = driver.FindElement(By.Id("Password"));
passwordtextbox.SendKeys("123123");


//Identify login button and click on it

IWebElement buttonlogin = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
buttonlogin.Click();

//Identify the logged person name on home page 
IWebElement nameofuser = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

//Checknameofuser if user is logged successfully
if (nameofuser.Text == "Hello hari!")
{
    Console.WriteLine("Login successful and Test passed ");
}
else
{
    Console.WriteLine("Login UNsuccessful and Test failed ");

}


//CREATE A RECORD

IWebElement adminDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
adminDropdown.Click();

IWebElement timeMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
timeMaterialOption.Click();

IWebElement createButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
createButton.Click();

//click typecode  select dropdown arrow and inspect for the locator

IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
typeCodeDropdown.Click();
//wait
Thread.Sleep(500);
//hover mouse on time option and then inspect 
IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
timeOption.Click();



IWebElement code = driver.FindElement(By.Id("Code"));
code.SendKeys("1010");

IWebElement DescTextbox = driver.FindElement(By.Id("Description"));

DescTextbox.SendKeys("Detail description 1010");

//find price
IWebElement priceInputTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));

priceInputTag.Click();
IWebElement pricetxtbox = driver.FindElement(By.Id("Price"));
pricetxtbox.SendKeys("10");


IWebElement Savebutton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
Savebutton.Click();

Thread.Sleep(3000);

//Validate created record
//find and click the last page button and goto to last page

IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPageButton.Click();
Thread.Sleep(1000);
// check the last record
IWebElement newCreatedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

if (newCreatedRecord.Text == "1010")
{
    Console.WriteLine("New Record is created successfully");
}
else
{
    Console.WriteLine("OOPs can't create new record");
}


//EDIT THE RECORD

//Find and click edit button for the record

IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
editButton.Click();



//Edit the Typecode

IWebElement typeCodeDropdown2 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
typeCodeDropdown2.Click();
Thread.Sleep(500);
IWebElement materialOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]"));
materialOption.Click();


//Edit the code
IWebElement codeTextBox1 = driver.FindElement(By.Id("Code"));
codeTextBox1.Clear();
codeTextBox1.SendKeys("editedcode1010");

//Edit the Description

IWebElement DescTextbox2 = driver.FindElement(By.Id("Description"));
DescTextbox2.Clear();
DescTextbox2.SendKeys("Edited /Updated description 1010");

//Edit the Price 

IWebElement priceInputTag2 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
priceInputTag2.Click();
IWebElement Price2 = driver.FindElement(By.Id("Price"));
Price2.Clear();

IWebElement priceInputTag3 = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
priceInputTag3.Click();
IWebElement Price3 = driver.FindElement(By.Id("Price"));
Price3.SendKeys("20");


IWebElement Savebutton2 = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
Savebutton2.Click();
Thread.Sleep(2000);


//Validate Edited Record

//Goto last page and check last record

IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
lastPageButton.Click();

IWebElement editedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

if (editedRecord.Text == "editedcode1010")
{
    Console.WriteLine("Record is edited successfully");
}
else
{
    Console.WriteLine("OOPs can't edit the record");
}


//DELETE THE RECORD

//Find and click Delete button for the record

IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));


deleteButton.Click();
Thread.Sleep(500);
// Click OK on Alert popup Window 

driver.SwitchTo().Alert().Accept();
Thread.Sleep(2000);

//VALIDATE DELETE
IWebElement deletedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));


if (deletedRecord.Text == "editedcode1010")
{
    Console.WriteLine("Record is NOT Deleted ");
}
else
{
    Console.WriteLine("Selected Record is Deleted ");
}





