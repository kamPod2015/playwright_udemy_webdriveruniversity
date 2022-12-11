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

    [Test,Description("ContactUsPage")]
    public async Task FillAndClearContactForm()
    {
        var website = "https://webdriveruniversity.com/Contact-Us/contactus.html";

        await Page.GotoAsync(website);
        await Expect(Page).ToHaveTitleAsync(new Regex("Contact Us"));
        await Page.GetByPlaceholder("First Name").FillAsync("Jan");
        await Page.GetByPlaceholder("Last Name").FillAsync("Kowalski");
        await Page.GetByPlaceholder("Email Address").FillAsync("jan.kowalski@test.com");
        await Page.GetByPlaceholder("Comments").FillAsync("Testowy komentarz Jana Kowalskiego !@#$%^&*()kropka.");
        await Page.Locator("#form_buttons > input:nth-child(1)").ClickAsync();
        await Expect(Page.GetByPlaceholder("First Name")).ToBeEmptyAsync();
        await Expect(Page.GetByPlaceholder("Last Name")).ToBeEmptyAsync();
        await Expect(Page.GetByPlaceholder("Email Address")).ToBeEmptyAsync();
        await Expect(Page.GetByPlaceholder("Comments")).ToBeEmptyAsync();
    }

    [Test,Description("ContactUsPage")]
    public async Task FillPartiallyAndTryToSendContactForm()
    {
        var website = "https://webdriveruniversity.com/Contact-Us/contactus.html";
        var errorMsg = "Error: all fields are required";

        await Page.GotoAsync(website);
        await Expect(Page).ToHaveTitleAsync(new Regex("Contact Us"));
        await Page.GetByPlaceholder("First Name").FillAsync("Jan");
        await Page.GetByPlaceholder("Last Name").FillAsync("Kowalski");
        await Page.GetByPlaceholder("Email Address").FillAsync("jankowalski@test.com");
        await Page.Locator("#form_buttons > input:nth-child(2)").ClickAsync();
        await Expect(Page).ToHaveURLAsync(urlOrRegExp: new Regex(".*contact_us.php"));
        await Expect(Page.GetByText(errorMsg)).ToContainTextAsync(errorMsg);
    }
    
    [Test,Description("ContactUsPage")]
    public async Task FillInvalidEmailAndTryToSendContactForm()
    {
        var website = "https://webdriveruniversity.com/Contact-Us/contactus.html";
        var errorMsg = "Error: Invalid email address";

        await Page.GotoAsync(website);
        await Expect(Page).ToHaveTitleAsync(new Regex("Contact Us"));
        await Page.GetByPlaceholder("First Name").FillAsync("Jan");
        await Page.GetByPlaceholder("Last Name").FillAsync("Kowalski");
        await Page.GetByPlaceholder("Email Address").FillAsync("jan.kowalski@test");
        await Page.GetByPlaceholder("Comments").FillAsync("Testowy komentarz Jana Kowalskiego !@#$%^&*()kropka.");
        await Page.Locator("#form_buttons > input:nth-child(2)").ClickAsync();
        await Expect(Page).ToHaveURLAsync(urlOrRegExp: new Regex(".*contact_us.php"));
        await Expect(Page.GetByText(errorMsg)).ToContainTextAsync(errorMsg);
    }
        
    [Test,Description("ContactUsPage")]
    public async Task FillProperlyAndSendContactForm()
    {
        var website = "https://webdriveruniversity.com/Contact-Us/contactus.html";
        var successMsg = "Thank You for your Message!";

        await Page.GotoAsync(website);
        await Expect(Page).ToHaveTitleAsync(new Regex("Contact Us"));
        await Page.GetByPlaceholder("First Name").FillAsync("Jan");
        await Page.GetByPlaceholder("Last Name").FillAsync("Kowalski");
        await Page.GetByPlaceholder("Email Address").FillAsync("jan.kowalski@test.com");
        await Page.GetByPlaceholder("Comments").FillAsync("Testowy komentarz Jana Kowalskiego !@#$%^&*()kropka.");
        await Page.Locator("#form_buttons > input:nth-child(2)").ClickAsync();
        await Expect(Page).ToHaveURLAsync(urlOrRegExp: new Regex(".*contact-form-thank-you.html"));                
        await Page.PauseAsync();
        await Expect(Page.Locator("h1")).ToContainTextAsync(successMsg);
    }        

    [Test,Description("DropdownCheckboxesRadioButtonsPage")]
    public async Task DropdownMenuValues()
    {
        var website = "https://webdriveruniversity.com/Dropdown-Checkboxes-RadioButtons/index.html";

        await Page.GotoAsync(website);
        await Expect(Page).ToHaveTitleAsync(new Regex("Dropdown Menu(s), Checkboxe(s) & Radio Button(s)"));
        await Page.GetByPlaceholder("First Name").FillAsync("Jan");
        await Page.GetByPlaceholder("Last Name").FillAsync("Kowalski");
        await Page.GetByPlaceholder("Email Address").FillAsync("jan.kowalski@test.com");
        await Page.GetByPlaceholder("Comments").FillAsync("Testowy komentarz Jana Kowalskiego !@#$%^&*()kropka.");
        await Page.Locator("#form_buttons > input:nth-child(2)").ClickAsync();
        await Expect(Page).ToHaveURLAsync(urlOrRegExp: new Regex(".*contact-form-thank-you.html"));                

    }
}
