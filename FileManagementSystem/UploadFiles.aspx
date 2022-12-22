<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UploadFiles.aspx.cs" Inherits="FileManagementSystem.UploadFiles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container-fluid">

      <div class="row">

         <div class="col-md-5">

            <div class="card">

               <div class="card-body">

                  <div class="row">

                     <div class="col">

                        <center>

                           <h4>File Details</h4>

                        </center>

                     </div>

                  </div>

                  <div class="row">

                     <div class="col">

                        <center>

                           <img id="imgview" Height="150px" Width="150px" src="Imgs/files.jpg"   />

                        </center>

                     </div>

                  </div>

                  <div class="row">

                     <div class="col">

                        <hr>

                     </div>

                  </div>

                  <div class="row">

                     <div class="col">

                        <asp:FileUpload  class="form-control" ID="FileUpload1" runat="server" />

                     </div>

                  </div>

                   <div class="row">

                     

                    

                  

                     <div class="col-md-12">

                        <label>File Name</label>

                        <div class="form-group">

                           <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="File Name"></asp:TextBox>

                        </div>

                     </div>

                  </div>

                  <div class="row">

                     <div class="col-6">

                         <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" onClick="Button1_Click" Text="Upload" />

                     </div>

                   

                     <div class="col-6">

                        <asp:Button ID="Button2" class="btn btn-lg btn-block btn-danger" runat="server" OnClick="Button2_Click" Text="Delete"  />

                     </div>

                  </div>

                

                  

                  

                  </div>

              

            </div>

            <a href="homepage.aspx"><< Back to Home</a><br>

            <br>

         </div>

         <div class="col-md-7">

            <div class="card">

               <div class="card-body">

                  <div class="row">

                     <div class="col">

                        <center>

                           <h4>File List</h4>

                        </center>

                     </div>

                  </div>

                  <div class="row">

                     <div class="col">

                        <hr>

                     </div>

                  </div>

                  <div class="row">

                    

                     <div class="col">

                         <hr>

                     </div>

                  </div>

                  <div class="row">

                    
                      <div class="col">

                     
                           <asp:GridView ID="gvFiles" runat="server" AutoGenerateColumns="False" Width="100%"  
                            OnRowCommand="gvFiles_RowCommand">
                                <Columns>
                                     <asp:TemplateField>

                                 <ItemTemplate>

                                    <div class="container-fluid">

                                       <div class="row">

                                          <div class="col-lg-10">

                                             <div class="row">

                                                <div class="col-12">

                                                   <asp:LinkButton ID="lnkDownload" runat="server" CausesValidation="False" CommandArgument='<%# Eval("File_Name") %>'  
                                            CommandName="Download" Text='<%# Eval("File_Name") %>' />  

                                                </div>

                                             </div>

 

                                           

                                            

                                            

                                             <div class="row">

                                                <div class="col-12">

                                                   Description -

                                                   <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Smaller" Text='<%# Eval("Date") %>'></asp:Label>

                                                </div>

                                             </div>

                                          </div>

                                          

                                       </div>

                                    </div>

                                 </ItemTemplate>

                              </asp:TemplateField>
                              <asp:BoundField DataField="File_type" HeaderText="File Type" ReadOnly="True"  >

                                 <ControlStyle Font-Bold="True" />

                                 <ItemStyle Font-Bold="True" />

                              </asp:BoundField>

                             

                           </Columns>
                               </asp:GridView>
                                 

                  </div>
                      </div>
                  <div class="row">
                      
                                <asp:DropDownList ID="Users" runat="server" DataSourceID="SqlDataSource2" DataTextField="User_Name" DataValueField="User_Name" ></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:fmsConnectionString %>" SelectCommand="SELECT [User_Name] FROM [user_table]"></asp:SqlDataSource>
                  </div>
               </div>

            </div>

         </div>

      </div>

   </div> 
   
</asp:Content>