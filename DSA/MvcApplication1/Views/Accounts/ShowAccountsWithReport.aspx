<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.ReportModel>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowAccountsWithReport</title>
</head>
<body>
    <div>
    <h2>Account Details</h2>
        <table class="text">
            <tr>
                <td>
                    Account ID 
                </td>
                <td>
                    Account type
                </td>
                <td>
                    Account Friendly name
                </td>
                <td>
                    Balance
                </td>
                <td>
                    Currency
                </td>
            </tr>
            <tr>
                <td>
                    <%: Model.accc.AccountID %>
                </td>
                <td>
                    <%: Model.accc.AccountType.AccountType1 %>
                </td>
                <td>
                    <%: Model.accc.AccountFriendlyName %>
                </td>
                <td>
                    <%: Model.accc.Balance%>
                </td>
                <td>
                    <%: Model.accc.Currency.Currency1%>
                </td>
            </tr>
        </table>

        <br />


        

         
          <h2>Transaction Details</h2>
        <%foreach (var item in Model.transactionlist)
          {%>
          <table style="text-align:center; width:90%;">
            <tr>
                <td>
                    Date
                </td>
                <td>
                    From Account
                </td>
                <td>
                    To Account
                </td>
                <td>
                    Currency
                </td>
                <td>
                    Ammount
                </td>
            </tr>
         
          
      
          
            <tr>
                <td>
                    <%: item.Date %>
                </td>
                <td>
                    <%: item.FromAccountID %>
                </td>
                <td>
                    <%: item.ToAccountID %>
                </td>
                <td>
                    <%: item.CurrencyID %>
                </td>
                <td>
                    <%: item.Amount %>
                </td>
            </tr>
        </table>

        <%  } %>
        
    </div>
</body>
</html>
