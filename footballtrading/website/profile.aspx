<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="profile.aspx.cs" Inherits="profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="stylesheet" href="style/stad.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" language="javascript">
        function Confirmation()
        {
        if (confirm("Are you sure, you want to delete selected records ?")==true)
           return true;
        else
           return false;
        }
        function RefreshPage() {
            window.location.reload()
        }
    </script>
    <form runat="server" onsubmit="RefreshPage()">
        <div class="wcent">
                <div class="wrapperr">
                    <div class="containor">
                        <div class="row">
                            <div class="col">
                                <div class="row">
                                    <h1><%=username %>'s profile</h1>
                                </div>
                                <div class="row">
                                    <p>change your username</p>
                                    <asp:TextBox ID="pswdtxt" runat="server"></asp:TextBox>
                                    <asp:Button ID="pswdsub" runat="server" Text="Button" AutoCompleteType="Disabled" onclick="pswdsub_Click"/>
                                    <hr />
                                </div>
                                <div class="row">
                                    <p> delete user warning this is permenenat</p>
                                    <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="return Confirmation();" onclick="delbtn_Click"/>
                                </div>
                            </div>
                            <div class="col">
                                <div id="admin" runat="server" visible="false" class="row">
                                    <%=allUsers %>
                                    <input type="submit" id="del" name="submitter" value="delete">
                                    <input type="submit" id="adm" name="submitter" value="admin">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </form>
</asp:Content>
