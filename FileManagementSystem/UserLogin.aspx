<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="FileManagementSystem.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col"> 
                                <center> 
                                    <img width="150px" src="Imgs/user.jpg" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Member Login</h3>
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Member Id</label>
                                <div class="form-group">
                                    <asp:TextBox Css Class="form-control" ID="TextBox1" 
                                        runat="server" placeholder="Member Id"></asp:TextBox>
                                </div>

                                <label>Member Password</label>
                                <div class="form-group">
                                    <asp:TextBox Css Class="form-control" ID="TextBox2" 
                                        runat="server" placeholder="Password" Textmode="Password"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:Button Class="btn btn-success btn-block btn-lg" ID="Button" runat="server" Text="Login" OnClick="Button_Click" />
                                </div>

                                <div class="form-group">
                                    <a href="SignUp.aspx"><input  Class="btn btn-info btn-block btn-lg" id="Button2" type="button" 
                                        value="Sign Up" /> </a>
                                </div>
                                


                            </div>
                        </div>
                    </div>
                </div>
                <a href="HomePage.aspx"><< Back to Home</a>
            </div>
        </div>


    </div>

</asp:Content>
