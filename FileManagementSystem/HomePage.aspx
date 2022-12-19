<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="FileManagementSystem.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section>
        <img src="Imgs/Top-Free-and-Open-Source-Document-Management-System-1.png" />
    </section>

    <div class="container">
        <div class="row">
            <div class="col-12">
                <center>
                    <h2>Our Features</h2>
                    <p><b>Our 3 Primary Features -</b></p>
                </center>

            </div>
        </div>

         <div class="row">
            <div class="col-md-4">
                <center>
                <img width="150" src="Imgs/Inventory.jpg" />
                <h4>File Inventory</h4>
                <p class="text-justify">An inventory file is a document containing listings, usually electronic, of every item
                   in a company's inventory, including items in stock or expected to be in stock shortly. 
                   Items are listed and identified by categories, and are put in a particular inventory group depending on item attributes.</p>
                </center>

            </div>

             <div class="col-md-4">
                <center>
                <img width="150px" src="Imgs/search.jpg" />
                <h4>Search Files</h4>
                <p class="text-justify">As you begin searching for files, the results show up instantly — there's no need to wait 
                    or press Enter. Newly added or modified files are added in real-time, so there's no need to manually re-index 
                    the database.It takes one second to index around a million files.</p>
                </center>

            </div>

             <div class="col-md-4">
                <center>
                <img width="150px" src="Imgs/Access Control.jpg" />
                <h4>Access Control</h4>
                <p class="text-justify">An ACL is a list of permissions that are associated with a directory or file. It defines 
                    which users are allowed to access a particular directory or file. An access control entry in the ACL defines 
                    the permissions for a user or a group of users. An ACL usually consists of multiple entries.</p>
                </center>

            </div>
        </div>
    </div>
</asp:Content>
