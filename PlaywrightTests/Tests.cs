using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace PlaywrightTests;

public class Tests : PageTest
{
    [SetUp]
    public void Setup()
    {
    }

    // [Test,Description("ContactUsPage")]
    // public async Task FillAndClearContactForm()
    // {
    //     var website = "https://webdriveruniversity.com/Contact-Us/contactus.html";

    //     await Page.GotoAsync(website);
    //     await Expect(Page).ToHaveTitleAsync(new Regex("Contact Us"));
    //     await Page.GetByPlaceholder("First Name").FillAsync("Jan");
    //     await Page.GetByPlaceholder("Last Name").FillAsync("Kowalski");
    //     await Page.GetByPlaceholder("Email Address").FillAsync("jan.kowalski@test.com");
    //     await Page.GetByPlaceholder("Comments").FillAsync("Testowy komentarz Jana Kowalskiego !@#$%^&*()kropka.");
    //     await Page.Locator("#form_buttons > input:nth-child(1)").ClickAsync();
    //     await Expect(Page.GetByPlaceholder("First Name")).ToBeEmptyAsync();
    //     await Expect(Page.GetByPlaceholder("Last Name")).ToBeEmptyAsync();
    //     await Expect(Page.GetByPlaceholder("Email Address")).ToBeEmptyAsync();
    //     await Expect(Page.GetByPlaceholder("Comments")).ToBeEmptyAsync();
    // }

    // [Test,Description("ContactUsPage")]
    // public async Task FillPartiallyAndTryToSendContactForm()
    // {
    //     var website = "https://webdriveruniversity.com/Contact-Us/contactus.html";
    //     var errorMsg = "Error: all fields are required";

    //     await Page.GotoAsync(website);
    //     await Expect(Page).ToHaveTitleAsync(new Regex("Contact Us"));
    //     await Page.GetByPlaceholder("First Name").FillAsync("Jan");
    //     await Page.GetByPlaceholder("Last Name").FillAsync("Kowalski");
    //     await Page.GetByPlaceholder("Email Address").FillAsync("jankowalski@test.com");
    //     await Page.Locator("#form_buttons > input:nth-child(2)").ClickAsync();
    //     await Expect(Page).ToHaveURLAsync(urlOrRegExp: new Regex(".*contact_us.php"));
    //     await Expect(Page.GetByText(errorMsg)).ToContainTextAsync(errorMsg);
    // }
    
    // [Test,Description("ContactUsPage")]
    // public async Task FillInvalidEmailAndTryToSendContactForm()
    // {
    //     var website = "https://webdriveruniversity.com/Contact-Us/contactus.html";
    //     var errorMsg = "Error: Invalid email address";

    //     await Page.GotoAsync(website);
    //     await Expect(Page).ToHaveTitleAsync(new Regex("Contact Us"));
    //     await Page.GetByPlaceholder("First Name").FillAsync("Jan");
    //     await Page.GetByPlaceholder("Last Name").FillAsync("Kowalski");
    //     await Page.GetByPlaceholder("Email Address").FillAsync("jan.kowalski@test");
    //     await Page.GetByPlaceholder("Comments").FillAsync("Testowy komentarz Jana Kowalskiego !@#$%^&*()kropka.");
    //     await Page.Locator("#form_buttons > input:nth-child(2)").ClickAsync();
    //     await Expect(Page).ToHaveURLAsync(urlOrRegExp: new Regex(".*contact_us.php"));
    //     await Expect(Page.GetByText(errorMsg)).ToContainTextAsync(errorMsg);
    // }
        
    // [Test,Description("ContactUsPage")]
    // public async Task FillProperlyAndSendContactForm()
    // {
    //     var website = "https://webdriveruniversity.com/Contact-Us/contactus.html";
    //     var successMsg = "Thank You for your Message!";

    //     await Page.GotoAsync(website);
    //     await Expect(Page).ToHaveTitleAsync(new Regex("Contact Us"));
    //     await Page.GetByPlaceholder("First Name").FillAsync("Jan");
    //     await Page.GetByPlaceholder("Last Name").FillAsync("Kowalski");
    //     await Page.GetByPlaceholder("Email Address").FillAsync("jan.kowalski@test.com");
    //     await Page.GetByPlaceholder("Comments").FillAsync("Testowy komentarz Jana Kowalskiego !@#$%^&*()kropka.");
    //     await Page.Locator("#form_buttons > input:nth-child(2)").ClickAsync();
    //     await Expect(Page).ToHaveURLAsync(urlOrRegExp: new Regex(".*contact-form-thank-you.html"));                
    //     await Expect(Page.Locator("h1")).ToContainTextAsync(successMsg);
    // }        

    // [Test,Description("DropdownCheckboxesRadioButtonsPage")]
    // public async Task DropdownMenuValues()
    // {
    //     var website = "https://webdriveruniversity.com/Dropdown-Checkboxes-RadioButtons/index.html";
    //     string[] expectedLanguages = new string[] { "JAVA", "C#", "Python", "SQL" };
    //     string[] programmingTools = new string[] { "Eclipse", "Maven", "TestNG", "JUnit" };
    //     string[] programmingExtras = new string[] { "HTML", "CSS", "JavaScript", "JQuery" };

    //     await Page.GotoAsync(website);
    //     await Expect(Page).ToHaveTitleAsync(new Regex("WebDriver | Dropdown Menu(s) | Checkboxe(s) | Radio Button(s)"));
    //     await Page.Locator("#dropdowm-menu-1").SelectOptionAsync((expectedLanguages[1]).ToLower());
    //     await Expect(Page.Locator("#dropdowm-menu-1")).ToContainTextAsync(expectedLanguages[1]);
    //     await Page.Locator("#dropdowm-menu-1").SelectOptionAsync(expectedLanguages[2].ToLower());
    //     await Expect(Page.Locator("#dropdowm-menu-1")).ToContainTextAsync(expectedLanguages[2]);
    //     await Page.Locator("#dropdowm-menu-1").SelectOptionAsync(expectedLanguages[3].ToLower());
    //     await Expect(Page.Locator("#dropdowm-menu-1")).ToContainTextAsync(expectedLanguages[3]);  
    //     await Page.Locator("#dropdowm-menu-1").SelectOptionAsync(expectedLanguages[0].ToLower());
    //     await Expect(Page.Locator("#dropdowm-menu-1")).ToContainTextAsync(expectedLanguages[0]);            

    //     for (int i = 0; i < programmingTools.Length; i++)
    //     {
    //         await Page.Locator("#dropdowm-menu-2").SelectOptionAsync((programmingTools[i]).ToLower());
    //         await Expect(Page.Locator("#dropdowm-menu-2")).ToContainTextAsync(programmingTools[i]);            
    //     }

    //     for (int i = 0; i < programmingExtras.Length; i++)
    //     {
    //         await Page.Locator("#dropdowm-menu-3").SelectOptionAsync((programmingExtras[i]).ToLower());
    //         await Expect(Page.Locator("#dropdowm-menu-3")).ToContainTextAsync(programmingExtras[i]);            
    //     }
    // }

    // [Test,Description("DropdownCheckboxesRadioButtonsPage")]
    // public async Task CheckboxesMenuValues()
    // {
    //     var website = "https://webdriveruniversity.com/Dropdown-Checkboxes-RadioButtons/index.html";

    //     await Page.GotoAsync(website);
    //     await Expect(Page).ToHaveTitleAsync(new Regex("WebDriver | Dropdown Menu(s) | Checkboxe(s) | Radio Button(s)"));
    //     await Page.GetByText("Option 1").SetCheckedAsync(true);
    //     await Page.GetByText("Option 1").IsCheckedAsync();
    //     await Page.GetByText("Option 2").SetCheckedAsync(true);
    //     await Page.GetByText("Option 2").IsCheckedAsync();
    //     await Page.GetByText("Option 3").SetCheckedAsync(true);
    //     await Page.GetByText("Option 3").IsCheckedAsync();
    //     await Page.GetByText("Option 4").SetCheckedAsync(true);
    //     await Page.GetByText("Option 4").IsCheckedAsync();
    //     await Page.GetByText("Option 2").SetCheckedAsync(false);
    //     await Page.GetByText("Option 2").UncheckAsync();
    //     await Page.GetByText("Option 4").SetCheckedAsync(false);
    //     await Page.GetByText("Option 4").UncheckAsync();
    // }

    // [Test,Description("DropdownCheckboxesRadioButtonsPage")]
    // public async Task RadioButtonsMenuValues()
    // {
    //     var website = "https://webdriveruniversity.com/Dropdown-Checkboxes-RadioButtons/index.html";
    //     string[] expectedColors = new string[] { "Green", "Blue", "Yellow", "Orange", "Purple" };

    //     await Page.GotoAsync(website);
    //     await Expect(Page).ToHaveTitleAsync(new Regex("WebDriver | Dropdown Menu(s) | Checkboxe(s) | Radio Button(s)"));

    //     for (int i = 0; i < expectedColors.Length; i++)
    //     {
    //         await Page.CheckAsync(($"input[value='{expectedColors[i]}']").ToLower());
    //         await Page.IsCheckedAsync(($"input[value='{expectedColors[i]}']").ToLower());           
    //     }
    // }

    [Test,Description("DatepickerButtonsPage")]
    public async Task SalectDateDatepickerTest()
    {
        var website = "https://webdriveruniversity.com/Datepicker/index.html";
        DateTime basicDate = DateTime.Now;
        var expectedTodayDate = basicDate.ToString("MM-dd-yyyy");
        //var expectedTodayDate = "06-10-2020";

        await Page.GotoAsync(website);
        await Expect(Page).ToHaveTitleAsync(new Regex("WebDriver | Datepicker"));
        await Page.PauseAsync();
        
        await Page.Locator(".form-control").ClickAsync();
        await Page.Locator(".datepicker-days").IsVisibleAsync();
        await Page.Locator(".datepicker-days>.datepicker-switch").ClickAsync();
        await Page.Locator(".datepicker-months").IsVisibleAsync();
        await Page.Locator(".datepicker-months>.datepicker-switch").ClickAsync();
        await Page.Locator(".datepicker-years").IsVisibleAsync();
        await Page.GetByRole(AriaRole.Cell, new() { NameString = "2020" }).ClickAsync();
        await Page.Locator(".datepicker-months").IsVisibleAsync();
        await Page.GetByRole(AriaRole.Cell, new() { NameString = "Jun" }).ClickAsync();
        await Page.Locator(".datepicker-days").IsVisibleAsync();
        await Page.GetByRole(AriaRole.Cell, new() { NameString = basicDate.Day.ToString() }).ClickAsync();
        await Expect(Page.Locator(".form-control")).ToHaveValueAsync(expectedTodayDate); 

    }
}    

//dotnet test --settings .runsettings
// await Page.PauseAsync();

// Zakładamy repo na  githubie
// Ściągamy niezbędne rzeczy, zakładamy projekt i instalujemy Cypressa
// Automatyzujemy stronę Contact US  
// Uzupełniamy wszystkie dane, i resetujemy - weryfikujemy czy wyczyściło poprawnie
// Wprowadzamy cześć danych i próbujemy wysłać - sprawdzamy komunikat błędu
// Wprowadzamy błędny email i sprawdzamy komunikat
// Wprowadzamy wszystkie dane i sprawdzamy komunikat
// Automatyzujemy stronę Dropdown Menu(s), Checkboxe(s) & Radio Button(s)
// Wybieramy wszystkie możliwe opcje z dropdownow i sprawdzamy ich wartości czy są poprawne
// Zaznaczamy wszystkie checkboxy a następnie odznaczamy 2 i 4 - sprawdzamy czy  zostały odznaczone i zaznaczone poprawnie
// Klikamy wszystkie Radio buttony po każdym kliknięciu sprawdzamy czy zaznaczył się ten który chcieliśmy

// Automatyzujemy stronę Datepicker - wpisujemy date i sprawdzamy czy została wybrana poprawna
// Automatyzujemy stronę Autocomplete TextField - wpisujemy 3 pierwsze znaki i wybieramy 2 element z listy podpowiadanej np. ('chi')
// Automatyzujemy stronę Ajax-Loader - czekamy aż strona się załaduje(bez statycznych waitow) i klikamy guzik