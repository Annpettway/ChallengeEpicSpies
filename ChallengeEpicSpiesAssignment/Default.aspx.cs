using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeEpicSpiesAssignment
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                endDateCalendar.SelectedDate = DateTime.Now.Date;
                startDateCalendar.SelectedDate = DateTime.Now.Date.AddDays(14);
                projectedEndCalendar.SelectedDate = DateTime.Now.Date.AddDays(21);
            }

        }

        protected void assignSpyButton_Click(object sender, EventArgs e)
        {
            resultLabel.Text = "";
            int totalDays = 0;
            
            DateTime prevAssignDay = endDateCalendar.SelectedDate;
            int dayOne = prevAssignDay.DayOfYear;
            DateTime newAssignStartDay = startDateCalendar.SelectedDate;
            int dayTwo = newAssignStartDay.DayOfYear;
            DateTime newAssignEndDay = projectedEndCalendar.SelectedDate;
            int dayThree = newAssignEndDay.DayOfYear;

            if (dayTwo - dayOne < 14) 

            {
                resultLabel.Text = "Error:  Must allow at least two weeks between previous assignment and new assignment.";

            }

            else
            {
                totalDays = dayThree - dayTwo;
                int totalBudget = totalDays * 500;
                if (dayThree - dayTwo > 21)
                {
                    totalBudget += 1000;
                }

                resultLabel.Text = String.Format("Assignment of {0} to assignment:{1} is authorized. Budget Total: {2:C}",
                codeNameTextBox.Text, newAssignTextBox.Text, totalBudget);
            }
        }

    }

}
        
