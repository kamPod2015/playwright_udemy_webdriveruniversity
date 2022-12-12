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

    [Test,Description("DropdownCheckboxesRadioButtonsPage")]
    public async Task DropdownMenuValues()
    {
        var website = "https://webdriveruniversity.com/Dropdown-Checkboxes-RadioButtons/index.html";
        string[] expectedLanguages = new string[] { "JAVA", "C#", "Python", "SQL" };
        string[] programmingTools = new string[] { "Eclipse", "Maven", "TestNG", "JUnit" };
        string[] programmingExtras = new string[] { "HTML", "CSS", "JavaScript", "JQuery" };

        await Page.GotoAsync(website);
        await Expect(Page).ToHaveTitleAsync(new Regex("WebDriver | Dropdown Menu(s) | Checkboxe(s) | Radio Button(s)"));
        await Page.Locator("#dropdowm-menu-1").SelectOptionAsync((expectedLanguages[1]).ToLower());
        await Expect(Page.Locator("#dropdowm-menu-1")).ToContainTextAsync(expectedLanguages[1]);
        await Page.Locator("#dropdowm-menu-1").SelectOptionAsync(expectedLanguages[2].ToLower());
        await Expect(Page.Locator("#dropdowm-menu-1")).ToContainTextAsync(expectedLanguages[2]);
        await Page.Locator("#dropdowm-menu-1").SelectOptionAsync(expectedLanguages[3].ToLower());
        await Expect(Page.Locator("#dropdowm-menu-1")).ToContainTextAsync(expectedLanguages[3]);  
        await Page.Locator("#dropdowm-menu-1").SelectOptionAsync(expectedLanguages[0].ToLower());
        await Expect(Page.Locator("#dropdowm-menu-1")).ToContainTextAsync(expectedLanguages[0]);            

        for (int i = 0; i < programmingTools.Length; i++)
        {
            await Page.Locator("#dropdowm-menu-2").SelectOptionAsync((programmingTools[i]).ToLower());
            await Expect(Page.Locator("#dropdowm-menu-2")).ToContainTextAsync(programmingTools[i]);            
        }

        await Page.PauseAsync();
        for (int i = 0; i < programmingExtras.Length; i++)
        {
            await Page.Locator("#dropdowm-menu-3").SelectOptionAsync((programmingExtras[i]).ToLower());
            await Expect(Page.Locator("#dropdowm-menu-3")).ToContainTextAsync(programmingExtras[i]);            
        }
    }
}

//dotnet test --settings .runsettings
