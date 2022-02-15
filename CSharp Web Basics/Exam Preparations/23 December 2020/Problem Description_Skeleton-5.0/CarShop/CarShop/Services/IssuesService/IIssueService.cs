using CarShop.Models;
using CarShop.ViewModels;
using System.Collections.Generic;

namespace CarShop.Services.IssuesService
{
    public interface IIssueService
    {
        User GetUser(string userId);

        Car GetCar(string carId);

        CarIssuesViewModel IssuesModel(string carId);

        ICollection<string> AddIssue(AddIssueViewModel issue, string userId);

        ICollection<string> FixIssue(string issueId);

        ICollection<string> DeleteIssue(string issueId, string carId);
    }
}
