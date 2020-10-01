<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Contact.ascx.cs" Inherits="Client_Contact" %>
<!-- Slider -->
<div class="blog margin-bottom-40 content-detail">
    <div class="row box-white mb10 mln mrn">
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
            
            <div id="form_register" runat="server">
                <div class="alert clr" role="alert">
                        <asp:Literal ID="LiteralContact" runat="server"></asp:Literal>
                    </div>

                <div class="panel panel-info">
                    <div class="panel-heading">Thông tin liên hệ</div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-3 control-label"><%= Resources.resource.Name %></label>
                                <div class="col-sm-9">
                                    <div class="input-group input-group-sm margin-10b">
                                         
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                                        <asp:TextBox ID="NameContact" ValidationGroup="Contact" runat="server" CssClass="form-control"
                                            placeholder="<%$ Resources:Resource, Name %>" aria-describedby="sizing-addon3"></asp:TextBox>
                                    </div>
                                </div>
                            </div>


                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-3 control-label"><%= Resources.resource.Company %></label>
                                <div class="col-sm-9">
                                        <div class="input-group input-group-sm margin-10b">
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                                        <asp:TextBox ID="Company" ValidationGroup="Contact" runat="server" CssClass="form-control"
                                            placeholder="<%$ Resources:Resource, Company %>" aria-describedby="sizing-addon3"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-3 control-label"><%= Resources.resource.Address %></label>
                                <div class="col-sm-9">
                                        <div class="input-group input-group-sm margin-10b">
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                                        <asp:TextBox ID="Address" ValidationGroup="Contact" runat="server" CssClass="form-control"
                                            placeholder="<%$ Resources:Resource, Address %>" aria-describedby="sizing-addon3"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-3 control-label"><%= Resources.resource.City %></label>
                                <div class="col-sm-9">
                                        <div class="input-group input-group-sm margin-10b">
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                                        <asp:TextBox ID="City" ValidationGroup="Contact" runat="server" CssClass="form-control"
                                            placeholder="<%$ Resources:Resource, City %>" aria-describedby="sizing-addon3"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-3 control-label"><%= Resources.resource.Telephone %></label>
                                <div class="col-sm-9">
                                        <div class="input-group input-group-sm margin-10b">
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                                        <asp:TextBox ID="Telephone" ValidationGroup="Contact" runat="server" CssClass="form-control"
                                            placeholder="<%$ Resources:Resource, Telephone %>" aria-describedby="sizing-addon3"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                             <div class="form-group">
                                <label for="inputEmail3" class="col-sm-3 control-label"><%= Resources.resource.Fax %></label>
                                <div class="col-sm-9">
                                        <div class="input-group input-group-sm margin-10b">
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                                        <asp:TextBox ID="Fax" ValidationGroup="Contact" runat="server" CssClass="form-control"
                                            placeholder="<%$ Resources:Resource, Fax %>" aria-describedby="sizing-addon3"></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-3 control-label"><%= Resources.resource.Email %></label>
                                <div class="col-sm-9">
                                        <div class="input-group input-group-sm margin-10b">
                                        <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                                         
                                        <asp:TextBox ID="Email" ValidationGroup="Contact" runat="server" CssClass="form-control"
                                            placeholder="<%$ Resources:Resource, Email %>" aria-describedby="sizing-addon3"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-3 control-label"><%= Resources.resource.Require %></label>
                                <div class="col-sm-9">
                                        <div class=" margin-10b">
                                        <asp:TextBox ID="Require" ValidationGroup="Contact" runat="server" CssClass="form-control" TextMode="MultiLine" Height="100px" Width="100%"
                                            placeholder="<%$ Resources:Resource, Require %>" aria-describedby="sizing-addon3"></asp:TextBox>
                                    </div>
                                </div>

                            </div>
                            
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-3 control-label"><%= Resources.resource.Capcha %></label>
                                <div class="col-sm-9">
                                    <div class="input-group input-group-sm margin-10b">
                                               
                                        <asp:TextBox ID="txtCapcha" ValidationGroup="Contact" runat="server" Width="100"
                                            CssClass="form-control" aria-describedby="sizing-addon3"></asp:TextBox>
                                        <img id="ImgCapcha" align="middle" alt="" runat="server" src="~/Client/Modules/Captcha/Image.aspx" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                            <div class="col-sm-offset-3 col-sm-5">
                                <asp:LinkButton runat="server" ID="LinkButton1" class="btn btn-default btn-sm" Text="<%$ Resources:Resource, T_Contact_reset_btn %>"
                                    ValidationGroup="Contact" />
                                <asp:LinkButton runat="server" ID="btnSendMail" class="btn btn-primary btn-sm" Text="<%$ Resources:Resource, T_Contact_send_btn %>"
                                    ValidationGroup="Contact" OnClick="contact_Click" />
                            </div>
                        </div>
         
                </div>
            </div>

            </div>
            </div>
            <div id="form_register_send" runat="server">
                <div class="alert alert-danger clr" role="alert">
                     <asp:Literal ID="ltlSucceed1" runat="server"></asp:Literal>
                </div>
                <div class="col-sm-offset-3 col-sm-5 mb20">
                <asp:LinkButton runat="server" ID="LinkButton2" class="btn btn-primary btn-sm" Text="Gửi tiếp" ValidationGroup="Contact_more" OnClick="btn_send_more" />
                </div>
            </div>
                
           
        </div>
    </div>

 
</div>