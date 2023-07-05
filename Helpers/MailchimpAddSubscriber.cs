using MailChimp.Net;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;

public async Task<ActionResult> SomeSampleController()
{               
    // Tested in .NET Framework 4.8, NuGet package MailChimp.Net.V3
  
    string apiKey = "TheApiKeyFromMailchimp";
    string listID = "TheListIdWhereToAddNewSubscriber";

    ServicePointManager.SecurityProtocol = ServicePointManager.SecurityProtocol | SecurityProtocolType.Tls12;
    IMailChimpManager mailChimpManager = new MailChimpManager(apiKey);
    
    // Use the Status property if updating an existing member
    var member = new Member { EmailAddress = $"TheEmailAddressToAdd", StatusIfNew = Status.Subscribed };
    member.MergeFields.Add("FNAME", "HOLY");
    member.MergeFields.Add("LNAME", "COW");
    await mailChimpManager.Members.AddOrUpdateAsync(listID, member);            

    return View();
}
