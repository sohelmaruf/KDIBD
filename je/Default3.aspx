<%@ Page Title="" Language="C#" MasterPageFile="MasterPage2.master" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="je_Default"
EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderMenu" Runat="Server">
    
    <script src="../js/jsUpdateProgress.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress1">
        <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
            <ProgressTemplate>
                <div style="position: relative; top: 30%; text-align: center; width: 150px; height: 150px;">
                    <img src="../images/loading.gif" style="vertical-align: middle"
                         alt="Processing" width="100px" height="100px" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </asp:Panel>
    <script type="text/javascript" language="javascript">
        var ModalProgress = '<%=ModalProgress.ClientID %>';         
    </script>
    <ajaxToolkit:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
                                    BackgroundCssClass="modalBackground" PopupControlID="panelUpdateProgress" />

    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always">
        <ContentTemplate>
            
    <ul class='sidebar-menu'>
        <li class='active'>
                <i class='fa fa-circle-o'></i>Menu
        </li>
                    
                        <i class='fa fa-circle-o'></i>
                        <asp:LinkButton ID="lbSelect" runat="server" CommandArgument='<%#Eval("id") %>' OnClick="lbSelect_Click">
                             <%#Eval("Name") %>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    <asp:Literal ID="lblMenuClient" runat="server"></asp:Literal>
        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton1_Command" CommandName="MyUpdate" CommandArgument='<%# Eval("id") %>'><%# Eval("Title") %></asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    <asp:Literal ID="lblMenuProposal" runat="server"></asp:Literal>
        <asp:Repeater ID="Repeater3" runat="server">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton1_Command" CommandName="MyUpdate" CommandArgument='<%# Eval("id") %>'><%# Eval("Name") %></asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    <asp:Literal ID="lblMenuProject1" runat="server"></asp:Literal>
        <asp:Repeater ID="Repeater4" runat="server">
            <ItemTemplate>
                <asp:LinkButton ID="LinkButton1" runat="server" OnCommand="LinkButton1_Command" CommandName="MyUpdate" CommandArgument='<%# Eval("id") %>'><%# Eval("Title") %></asp:LinkButton>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    </li>
    </ul>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Repeater1" EventName="ItemCreated" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
            <div class="card" id="divAddTask" runat="server" visible="False">
                <div class="card-header">
                    <div class="row">
                    <div class="col-lg-11">
                        Add Task
                    </div>
                    <div class="col-lg-1">
                        <asp:LinkButton ID="btnAddTaskClose" runat="server" OnClick="btnAddTaskClose_OnClick">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        </asp:LinkButton>
                    </div>
                    </div>
                </div>
                <div class="card-body">
                   <div class="form-group">
                            <label for="cc-task" class="control-label mb-1">Task Title</label>
                            <asp:TextBox runat="server" ID="txtTaskTitle" Name="txtPlanNumber" class="form-control cc-plannumber valid" data-val="true" data-val-required="Please enter task title"
                                    autocomplete="cc-plannumber" aria-required="true" aria-invalid="false" aria-describedby="cc-plannumber-error"></asp:TextBox>
                            <span class="help-block field-validation-valid" data-valmsg-for="cc-task" data-valmsg-replace="true"></span>
                        </div>
                        <div class="form-group">
                            <label for="cc-task_status" class="control-label mb-1">Task Status</label>
                            <asp:DropDownList runat="server" ID="ddlTaskStatusID" class="form-control-md form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="cc-assignd" class="control-label mb-1">Assigned To</label>
                            <asp:DropDownList runat="server" ID="ddlTaskAssignedTo" class="form-control-md form-control">
                            </asp:DropDownList>

                        </div>


                        <div class="form-group">
                            <label for="cc-dateline" class="control-label mb-1">Deadline</label>
                            <asp:TextBox runat="server" ID="txtDateline" type="date" class="form-control cc-start_date identified visa" value="" data-val="true"
                                         data-val-required="Please enter the due-date"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="cc-note" class="control-label mb-1">Short Description</label>
                            <asp:TextBox runat="server" ID="txtTaskShortDescription" Name="txtPlanNumber" class="form-control cc-plannumber valid" data-val="true" data-val-required="Please enter task short Description"
                                         autocomplete="cc-plannumber" aria-required="true" aria-invalid="false" aria-describedby="cc-plannumber-error"></asp:TextBox>
                        </div>


                        <div>
                            <div class="row">
                                <div class="col-lg-6">
                                    <asp:Button runat="server" ID="btnAddTaskForm" OnClick="btnAddTaskForm_OnClick" class="btn btn-lg btn-info btn-block" Text="Save"></asp:Button>
                                </div>
                                <div class="col-lg-6">
                                    <asp:Button runat="server" ID="Button2" OnClick="btnAddTaskClose_OnClick" class="btn btn-lg btn-danger btn-block" Text="Cancel"></asp:Button>
                
                                </div>
                            </div>
                        </div>
                </div>
            </div>
              <div class="card" id="divProjectEdit" runat="server" Visible="False">
        <asp:TextBox runat="server" ID="txtId" Visible="False"></asp:TextBox>
        <div class="card-header">
            <div class="row">
                <div class="col-lg-11">
                    <h3>Project Details</h3>
                </div>
                <div class="col-lg-1">
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="btnAddTaskClose_OnClick">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="form-group">
                <asp:Label runat="server" ID="lblMessage"></asp:Label>
            </div>
            <div class="form-group">
                <label for="cc-client" class="control-label mb-1">Client</label>

                <asp:DropDownList runat="server" ID="dropdownClient" class="form-control-md form-control">
                    <asp:ListItem Selected="True" Value="-1"> select Client </asp:ListItem>

                </asp:DropDownList>

            </div>
            <div class="form-group">
                <label for="cc-projectname" class="control-label mb-1">Project Name</label>
                <asp:TextBox ID="txtProjectName" name="txtPName" type="tel" class="form-control cc-projectname identified visa" value="" data-val="true" data-val-required="Please enter the  projectname"
                    data-val-cc-number="Please enter a valid card number" autocomplete="cc-projectname" runat="server"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-projectname" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-projectnumber" class="control-label mb-1">Project Number</label>
                <asp:TextBox ID="txtProjectNumber" name="txtPNumber" type="tel" class="form-control cc-projectnumber identified visa" value="" data-val="true" data-val-required="Please enter the  project number"
                    data-val-cc-number="Please enter a valid card number" autocomplete="cc-projectnumber" runat="server"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-projectnumber" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-project_status" class="control-label mb-1">Project Status</label>

                <asp:DropDownList runat="server" ID="dropdownProjectStatus" class="form-control-md form-control">
                </asp:DropDownList>

            </div>
            <div class="form-group">
                <label for="cc-priority" class="control-label mb-1">Project Priority</label>

                <asp:DropDownList runat="server" ID="dropDownProjectPriority" class="form-control-md form-control">
                </asp:DropDownList>

            </div>
            <div class="form-group">
                <label for="cc-planname" class="control-label mb-1">Plan Name</label>
                <asp:TextBox runat="server" ID="txtPlanName" Name="txtPlanName" class="form-control cc-planname valid" data-val="true" data-val-required="Please enter the plan name"
                    autocomplete="cc-planname" aria-required="true" aria-invalid="false" aria-describedby="cc-planname-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-planname" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-plannumber" class="control-label mb-1">Plan Number</label>
                <asp:TextBox runat="server" ID="txtPlanNumber" Name="txtPlanNumber" class="form-control cc-plannumber valid" data-val="true" data-val-required="Please enter the plan number"
                    autocomplete="cc-plannumber" aria-required="true" aria-invalid="false" aria-describedby="cc-plannumber-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-plannumber" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-start_date" class="control-label mb-1">Start Date</label>
                <asp:TextBox runat="server" ID="txtStartDate" type="date" class="form-control cc-start_date identified visa" value="" data-val="true"
                    data-val-required="Please enter the start-date"></asp:TextBox>

            </div>
            <div class="form-group">
                <label for="cc-Due_date" class="control-label mb-1">Due Date</label>
                <asp:TextBox runat="server" ID="txtDueDate" type="date" class="form-control cc-start_date identified visa" value="" data-val="true"
                    data-val-required="Please enter the due-date"></asp:TextBox>

            </div>
            <div class="jumbotron">
            <div class="form-group has-success">
                <label for="cc-address" class="control-label mb-1">Address</label>
                <asp:TextBox ID="txtAddress" name="txtAddress" class="form-control cc-address valid" data-val="true" data-val-required="Please enter the address"
                    autocomplete="cc-address" aria-required="true" aria-invalid="false" aria-describedby="cc-address-error" runat="server"> </asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-address" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-city" class="control-label mb-1">City</label>
                <asp:TextBox ID="txtCity" name="txtCity" type="tel" class="form-control cc-City identified visa" value="" data-val="true" data-val-required="Please enter the  City"
                    data-val-cc-number="Please enter a valid card number" autocomplete="cc-City" runat="server"></asp:TextBox>
                <span class="help-block" data-valmsg-for="cc-city" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-state" class="control-label mb-1">State</label>

                <asp:DropDownList runat="server" ID="dropdownState" class="form-control-md form-control">
                </asp:DropDownList>

            </div>
            <div class="form-group">
                <label for="cc-zipcode" class="control-label mb-1">Zip Code</label>
                <asp:TextBox ID="txtZipCode" name="txtZipCode" type="tel" class="form-control cc-zipcode identified visa" value="" data-val="true"
                    data-val-required="Please enter the zipcode" data-val-cc-zipcode="Please enter a valid zipcode"
                    autocomplete="cc-zipcode" runat="server"></asp:TextBox>
                <span class="help-block" data-valmsg-for="cc-zipcode" data-valmsg-replace="true"></span>
            </div>
            </div>
            <div class="form-group">
                <label for="cc-review" class="control-label mb-1">Projet Reviewed By</label>

                <asp:DropDownList runat="server" ID="DropDownProjetReviewed" class="form-control-md form-control">
                    <asp:ListItem Selected="True" Value="-1"> select Review </asp:ListItem>
                    <asp:ListItem Value="1"> Test user tasta </asp:ListItem>
                    <asp:ListItem Value="2"> omar </asp:ListItem>

                </asp:DropDownList>

            </div>
            <div class="form-group">
                <label for="cc-projecttype" class="control-label mb-1">Project Type</label>

                <asp:DropDownList runat="server" ID="DropDownProjectType" class="form-control-md form-control">
                </asp:DropDownList>

            </div>
            <div class="form-group">
                <label for="cc-projectnote" class="control-label mb-1">Project Type Note</label>
                <asp:TextBox runat="server" ID="txtProjectNote" Name="txtProjectNote" class="form-control cc-projectnote valid" data-val="true" data-val-required="Please enter the projectnote"
                    autocomplete="cc-projectnote" aria-required="true" aria-invalid="false" aria-describedby="cc-projectnote-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-projectnote" data-valmsg-replace="true"></span>
            </div>
        <div class="jumbotron">
            <div class="form-group">
                <label class="checkboxstyle">
                    Is Foundation
                             <asp:CheckBox ID="chkFoundation" runat="server" />
                    <span class="checkmark"></span>
                </label>
            </div>
            <div class="form-group">
                <label for="cc-foundationtype" class="control-label mb-1">Foundation Type</label>


                <asp:DropDownList runat="server" ID="DropDownFoundationType" class="form-control-md form-control">
                    <asp:ListItem Selected="True" Value="-1"> select Type </asp:ListItem>
                    <asp:ListItem Value="1"> Pier Beam </asp:ListItem>
                    <asp:ListItem Value="2"> Conventional Reinforced Slab w/o Piers </asp:ListItem>
                    <asp:ListItem Value="2"> Conventional Reinforced Slab w/o Piers </asp:ListItem>

                </asp:DropDownList>

            </div>
            <div class="form-group">
                <label for="cc-crawl" class="control-label mb-1">Crawl Space joist</label>

                <asp:TextBox runat="server" ID="txtCrawlSpace" Name="txtCrawlSpace" class="form-control cc-crawl valid" data-val="true" data-val-required="Please enter the crawl"
                    autocomplete="cc-crawl" aria-required="true" aria-invalid="false" aria-describedby="cc-crawl-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-crawl" data-valmsg-replace="true"></span>
            </div>
        </div>
        <div class="jumbotron">
            <div class="form-group">
                <label class="checkboxstyle">
                    Is Have Soils Report?
                                                    <asp:CheckBox ID="chkSoilReport" runat="server" />
                    <span class="checkmark"></span>
                </label>
            </div>
            <div class="form-group">
                <label for="cc-howsend" class="control-label mb-1">How/When Send?</label>

                <asp:TextBox runat="server" ID="txtHowSend" Name="txtHowSend" class="form-control cc-howsend valid" data-val="true" data-val-required="Please enter the how send"
                    autocomplete="cc-howsend" aria-required="true" aria-invalid="false" aria-describedby="cc-howsend-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-howsend" data-valmsg-replace="true"></span>
            </div>
        </div>
        <div class="jumbotron">
            <div class="form-group">
                <label class="checkboxstyle">
                    Is Framing?
                            <asp:CheckBox ID="chkIsFraming" runat="server" />
                    <span class="checkmark"></span>
                </label>
            </div>
            <div class="form-group">
                <label for="cc-floorjoist" class="control-label mb-1">Type of Floor joist</label>

                <asp:TextBox runat="server" ID="txtFloorjoist" Name="txtFloorjoist" class="form-control cc-floorjoist valid" data-val="true" data-val-required="Please enter the floor joist  ?"
                    autocomplete="cc-floorjoist" aria-required="true" aria-invalid="false" aria-describedby="cc-floorjoist-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-floorjoist" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-joistspace" class="control-label mb-1">Max Floor Joist Spacing?</label>

                <asp:TextBox runat="server" ID="txtFloorJoistSpacing" Name="txtFloorJoistSpacing" class="form-control cc-joistspace valid" data-val="true" data-val-required="Please enter the joist space  ?"
                    autocomplete="cc-joistspace" aria-required="true" aria-invalid="false" aria-describedby="cc-joistspace-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-joistspace" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-ceilingjoist" class="control-label mb-1">Type Of Ceiling Joist?</label>

                <asp:TextBox runat="server" ID="txtCeilingJoist" Name="txtCeilingJoist" class="form-control cc-ceilingjoist valid" data-val="true" data-val-required="Please enter the ceiling joist  ?"
                    autocomplete="cc-ceilingjoist" aria-required="true" aria-invalid="false" aria-describedby="cc-ceilingjoist-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-ceilingjoist" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-roofingmaterials" class="control-label mb-1">Roofing Materials?</label>

                <asp:TextBox runat="server" ID="txtRoofingMaterials" Name="txtRoofingMaterials" class="form-control cc-roofingmaterials valid" data-val="true" data-val-required="Please enter the roofing materials  ?"
                    autocomplete="cc-roofingmaterials" aria-required="true" aria-invalid="false" aria-describedby="cc-roofingmaterials-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-roofingmaterials" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-weightmaterials" class="control-label mb-1">Weight Of Roofing Materials?</label>

                <asp:TextBox runat="server" ID="txtWeightMaterials" Name="txtWeightMaterials" class="form-control cc-weightmaterials valid" data-val="true" data-val-required="Please enter the weight materials  ?"
                    autocomplete="cc-weightmaterials" aria-required="true" aria-invalid="false" aria-describedby="cc-weightmaterials-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-weightmaterials" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-materialnotes" class="control-label mb-1">Project Material Notes?</label>

                <asp:TextBox runat="server" ID="txtMaterialNotes" Name="txtMaterialNotes" class="form-control cc-materialnotes valid" data-val="true" data-val-required="Please enter the material notes ?"
                    autocomplete="cc-materialnotes" aria-required="true" aria-invalid="false" aria-describedby="cc-materialnotes-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-floorjoist" data-valmsg-replace="true"></span>
            </div>
        </div>
        <div class="jumbotron">
            <div class="form-group">
                <label class="checkboxstyle">
                    Is Have Courier Plans?
                                                    <asp:CheckBox ID="chkIsCourier" runat="server" />
                    <span class="checkmark"></span>
                </label>
            </div>
            <div class="form-group">
                <label for="cc-courier" class="control-label mb-1">Courier to Whom?</label>
                <asp:TextBox runat="server" ID="txtCourierWhom" Name="txtCourierWhom" class="form-control cc-courier valid" data-val="true" data-val-required="Please enter the courier ?"
                    autocomplete="cc-courier" aria-required="true" aria-invalid="false" aria-describedby="cc-courier-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-courier" data-valmsg-replace="true"></span>

            </div>
            <div class="form-group">
                <label for="cc-courieraddress" class="control-label mb-1">Courier to Address?</label>

                <asp:TextBox runat="server" ID="txtCourierAddress" Name="txtCourierAddress" class="form-control cc-courieraddress valid" data-val="true" data-val-required="Please enter the courier address?"
                    autocomplete="cc-courieraddress" aria-required="true" aria-invalid="false" aria-describedby="cc-courieraddress-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-courieraddress" data-valmsg-replace="true"></span>
            </div>
        
            <div class="form-group">
                <label class="checkboxstyle">
                    Is Have Email?
                            <asp:CheckBox ID="chkIsHaveEmail" runat="server" Checked="true" />
                    <span class="checkmark"></span>
                </label>
            </div>
            <div class="form-group">
                <label for="cc-emailaddress" class="control-label mb-1">Email Address?</label>

                <asp:TextBox runat="server" ID="txtEmailAddress" Name="txtEmailAddress" class="form-control cc-emailaddress valid" data-val="true" data-val-required="Please enter the email address?"
                    autocomplete="cc-emailaddress" aria-required="true" aria-invalid="false" aria-describedby="cc-emailaddress-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-emailaddress" data-valmsg-replace="true"></span>
            </div>
        </div>
        <div class="jumbotron">
            <div class="form-group">
                <label class="checkboxstyle">
                    Is client Will Pickup?
                            <asp:CheckBox ID="chkPickup" runat="server" />
                    <span class="checkmark"></span>
                </label>
            </div>
            <div class="form-group">
                <label for="cc-pickupperson" class="control-label mb-1">Pickup By Person Name?</label>

                <asp:TextBox runat="server" ID="txtPickPersonName" Name="txtPickPersonName" class="form-control cc-pickupperson valid" data-val="true" data-val-required="Please enter the number pick up person?"
                    autocomplete="cc-pickupperson" aria-required="true" aria-invalid="false" aria-describedby="cc-pickupperson-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-pickupperson" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-personphonenumber" class="control-label mb-1">Pickup By Person Phone Number?</label>

                <asp:TextBox runat="server" ID="txtPersonalPhoneNumber" Name="txtPersonalPhoneNumber" class="form-control cc-personphonenumber valid" data-val="true" data-val-required="Please enter the number person phone number?"
                    autocomplete="cc-personphonenumber" aria-required="true" aria-invalid="false" aria-describedby="cc-personphonenumber-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-personphonenumber" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-numbercopies" class="control-label mb-1">Number Of Copies?</label>

                <asp:TextBox runat="server" ID="txtNumberOfCopies" Name="txtNumberOfCopies" type="number" class="form-control cc-numbercopies valid" data-val="true" data-val-required="Please enter the number ofcopies?"
                    autocomplete="cc-numbercopies" aria-required="true" aria-invalid="false" aria-describedby="cc-numbercopies-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-numbercopies" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-holdernotice" class="control-label mb-1">Project Hold Notes?</label>

                <asp:TextBox runat="server" ID="txtHoldNote" Name="txtHoldNote" class="form-control cc-holdernotice valid" data-val="true" data-val-required="Please enter the holder notice?"
                    autocomplete="cc-holdernotice" aria-required="true" aria-invalid="false" aria-describedby="cc-holdernotice-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-holdernotice" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-clientdate" class="control-label mb-1">Client Data?</label>

                <asp:TextBox runat="server" ID="txtClientData" Name="txtClientData" class="form-control cc-clientdate valid" data-val="true" data-val-required="Please enter the client date?"
                    autocomplete="cc-clientdate" aria-required="true" aria-invalid="false" aria-describedby="cc-clientdate-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-clientdate" data-valmsg-replace="true"></span>
            </div>
            <div class="form-group">
                <label for="cc-clientinvoice" class="control-label mb-1">Client Invoice</label>
                <asp:TextBox runat="server" ID="txtClientInvoice" Name="txtClientInvoice" class="form-control cc-clientinvoice valid" data-val="true" data-val-required="Please enter the client invoice"
                    autocomplete="cc-clientinvoice" aria-required="true" aria-invalid="false" aria-describedby="cc-clientinvoice-error"></asp:TextBox>
                <span class="help-block field-validation-valid" data-valmsg-for="cc-clientinvoice" data-valmsg-replace="true"></span>
            </div>
        </div>
            <div class="row">
                <div class="col-lg-6">
                    <asp:Button runat="server" ID="Add" OnClick="btnAdd_OnClick" class="btn btn-lg btn-info btn-block" Text="Save"></asp:Button>
                </div>
                <div class="col-lg-6">
                    <asp:Button runat="server" ID="btnCancelProjectEdit" OnClick="btnAddTaskClose_OnClick" class="btn btn-lg btn-danger btn-block" Text="Cancel"></asp:Button>
                
                </div>
            </div>

        </div>
    </div>
<div class="card" id="div_TaskDetails" runat="server" Visible="False">
        <div class="card-header">
            <div class="row">
                <div class="col-lg-11">
                    <h3>Task Details</h3>
                </div>
                <div class="col-lg-1">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btnAddTaskClose_OnClick">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <div class="card-body">
            <div class="form-group">
                <asp:Label ID="lblTaskTitleDetails" runat="server" Text=""></asp:Label>
            </div>
            <div class="row">
                        <div class="col-lg-12">
                            <address class="mt-3">
                                <strong>Deadline</strong>
                                <br>
                                <asp:Label ID="lblTaskDetails_Deadline" runat="server" Text=""></asp:Label>
                                <br>
                                <strong>Assigned to : </strong>
                                <asp:Label ID="lblTaskDetails_AssignedTo" runat="server" Text=""></asp:Label>
                                <br>
                                <strong>Status : </strong>
                                <asp:Label ID="lblTaskDetails_TaskStatus" runat="server" Text=""></asp:Label>
                                <br>
                                <strong>Short Details</strong>
                                <br>
                                <asp:Label ID="lblTaskDetails_ShortDetails" runat="server" Text=""></asp:Label>
                                <br>
                                <strong>Full Description : </strong>
                                <asp:Label ID="lblTaskDetails_FullDescription" runat="server" Text=""></asp:Label>
                             
                            </address>
                        </div>
                      
                </div>
            <div class="row">
                <div class="col-lg-6">
                    <asp:Button runat="server" ID="btnAddNote" OnClick="btnAddNote_OnClick" class="btn btn-lg btn-info btn-block" Text="Add Note"></asp:Button>
                </div>
                <div class="col-lg-6">
                    <asp:Button runat="server" ID="Button3" OnClick="btnAddTaskClose_OnClick" class="btn btn-lg btn-danger btn-block" Text="Cancel"></asp:Button>
                
                </div>
            </div>

        </div>
    </div>

        </div>
        <div class="col-lg-2"></div>
    </div>

    <div class="row " id="divTaskList" runat="server">
        <div class="col-md-12">
            <!-- DATA TABLE -->
            <h3 class="title-5 m-b-5">Tasks</h3>
            <div class="table-data__tool">
                <div class="table-data__tool-left">
                    <asp:LinkButton ID="btnAddTask" runat="server"
                        OnClick="btnAddTask_onClick"
                        class="au-btn au-btn-icon au-btn--green au-btn--small">
                                                    <i class="zmdi zmdi-plus"></i>Add Task
                    </asp:LinkButton>

                    <div class="rs-select2--light rs-select2--md">
                        <select class="js-select2" name="property">
                            <option selected="selected">Short By</option>
                            <option value="">Task Title</option>
                            <option value="">Deadline</option>
                            <option value="">Status</option>
                        </select>
                        <div class="dropDownSelect2"></div>
                    </div>
                    <div class="rs-select2--light rs-select2--sm">
                        <select class="js-select2" name="time">
                            <option selected="selected">Today</option>
                            <option value="">3 Days</option>
                            <option value="">1 Week</option>
                            <option value="">This Month</option>
                            <option value="">Last Month</option>
                        </select>
                        <div class="dropDownSelect2"></div>
                    </div>
                    <%--<button class="au-btn-filter">
                                                    <i class="zmdi zmdi-filter-list"></i>filters</button>--%>
                </div>
                <div class="table-data__tool-right">

                    <div class="rs-select2--dark rs-select2--sm rs-select2--dark2">
                        <select class="js-select2" name="type">
                            <option selected="selected">Export</option>
                            <option value="">Option 1</option>
                            <option value="">Option 2</option>
                        </select>
                        <div class="dropDownSelect2"></div>
                    </div>
                </div>
            </div>
            <div class="table-responsive table-responsive-data2">
                <table class='table table-data2 taskList' >
                <thead>
                <tr>
                    <th>SI</th>
                    <th></th>
                    <th>Task Title</th>
                    <th>Project / Proposal</th>
                    <th>Client</th>
                    <th>Deadline</th>
                    <th>Status</th>
                </tr>
                </thead>
                <tbody>
                <asp:Repeater ID="rptrTaskList" runat="server"  OnItemCommand="rptrTaskList_ItemCommand">
                    <ItemTemplate>
                        
                        <tr class='tr-shadow'>
                            <td><%#Eval("RowNo") %></td>
                            <td>
                                <div class='table-data-feature'>
                                    <asp:LinkButton ID="LinkButton3" runat="server">
                                        <button class='item' data-toggle='tooltip' data-placement='top' title='Edit'>
                                            <i class='zmdi zmdi-edit'></i>
                                        </button>
                                    </asp:LinkButton>
                                </div>
                            </td>
                            <td>
                                
                                <%#Eval("TaskName") %>
                                
                            </td>
                            <td>
                                <span class='block-email'><%#Eval("ProjectTitle") %></span>
                            </td>
                            <td class='desc'><%#Eval("ClientTitle") %></td>
                            
                            <td><%#Eval("Deadline") %></td>
                            <td>
                                <span class='status--process'><%#Eval("StatusTitle") %></span>
                            </td>
                            
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                    </tbody>
                </table>
                <asp:Label ID="lblTaskList" runat="server" Text=""></asp:Label>
            </div>
            <!-- END DATA TABLE -->
        </div>
    </div>
    <br/>
        <div class="card" id="divProjectView" runat="server">
            <div class="card-header">
                <h3>
                    <asp:LinkButton ID="btnProjectViewEdit" runat="server" OnClick="btnProjectViewEdit_OnClick">
                        <button class="item" data-toggle="tooltip" data-placement="top" title="Edit">
                            <i class="zmdi zmdi-edit"></i>
                        </button>
                    </asp:LinkButton>
                    &nbsp;
                    &nbsp;
                    &nbsp;
                    <asp:Label ID="lblProjectDetails_ProjectName" runat="server" Text=""></asp:Label>
                </h3>
            </div>
            <div class="card-body">
                <div class="row">
                        <div class="col-lg-4">
                            <address class="mt-3">
                                <strong>Client</strong>
                                <br>
                                <asp:Label ID="lblProjectDetails_ClientName" runat="server" Text=""></asp:Label>
                                <br>
                                <br>
                                <strong>Project Number : </strong>
                                <asp:Label ID="lblProjectDetails_ProjectNumber" runat="server" Text=""></asp:Label>
                                <br>
                                <br>
                                <strong>Priority : </strong>
                                <asp:Label ID="lblProjectDetails_Priority" runat="server" Text=""></asp:Label>
                                <br>
                                <br>
                                <strong>Status</strong>
                                <br>
                                <asp:Label ID="lblProjectDetails_ProjectStatus" runat="server" Text=""></asp:Label>
                                <br>
                                <br>
                                <strong>Type : </strong>
                                <asp:Label ID="lblProjectDetails_ProjectType" runat="server" Text=""></asp:Label>
                                <br>
                                <br>
                                <strong>Plan Name</strong>
                                <br>
                                <asp:Label ID="lblProjectDetails_PlanName" runat="server" Text=""></asp:Label>
                                <br>
                                <br>
                                <strong>Plan Number : </strong>
                                <asp:Label ID="lblProjectDetails_PlanNumber" runat="server" Text=""></asp:Label>

                            </address>
                        </div>
                        <div class="col-lg-4">
                            <address class="mt-3">
                                <strong>Address</strong>
                                <br>
                                <asp:Label ID="lblProjectDetails_JobAddress" runat="server" Text=""></asp:Label>
                                <br>
                                <strong>City : </strong>
                                <asp:Label ID="lblProjectDetails_JobCity" runat="server" Text=""></asp:Label>
                                <br>
                                <strong>State : </strong>
                                <asp:Label ID="lblProjectDetails_JobState" runat="server" Text=""></asp:Label>
                                <br>
                                <strong>Zip : </strong>
                                <asp:Label ID="lblProjectDetails_JobZip" runat="server" Text=""></asp:Label>
                                <br>
                                <br>
                                <strong>Start Date : </strong>
                                <asp:Label ID="lblProjectDetails_StartDate" runat="server" Text=""></asp:Label>
                                <br>
                                <strong>Due Date : </strong>
                                <asp:Label ID="lblProjectDetails_DueDate" runat="server" Text=""></asp:Label>

                            </address>
                        </div>
                        <div class="col-lg-4">
                            <strong>Reviewed By</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_ReviewedBy" runat="server" Text=""></asp:Label>

                            <br><br>
                            <strong>Project Type Note</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_ProjectTypeNote" runat="server" Text=""></asp:Label>
                            <br>
                            <br>
                            <strong>
                                Number Of Copies</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_NumberOfCopies" runat="server" Text=""></asp:Label>
                            <br>
                            <strong>
                                Project Hold Notes</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_ProjectHoldHotes" runat="server" Text=""></asp:Label>
                            <br>
                            <strong>
                                Customer Data</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_CustomerData" runat="server" Text=""></asp:Label>
                            <br>
                            <strong>Invoice</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_Invoice" runat="server" Text=""></asp:Label>
                        </div>
                </div>
                <div class="row">
                        <div class="col-lg-4">
                            <div class="jumbotron">
                                <strong>Is Foundateion? --></strong>
                            <asp:Label ID="lblProjectDetails_IsFoundation" runat="server" Text=""></asp:Label>
                            <br>
                                <br>
                                <strong>Foundation Type</strong>
                                <br>
                                <asp:Label ID="lblProjectDetails_FoundationType" runat="server" Text=""></asp:Label>
                            <br>
                                <br>
                                <strong>Crawl Space Joist</strong>
                                <br>
                                <asp:Label ID="lblProjectDetails_FoundationCrawlSpaceJoist" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="jumbotron">
                                <strong>Is Have Soils Report? --></strong>
                                <asp:Label ID="lblProjectDetails_IsHaveSoilsReport" runat="server" Text=""></asp:Label>
                            <br>
                                <br>
                                <strong>How/When Send?</strong>
                                <br>
                                <asp:Label ID="lblProjectDetails_SoilReportSent" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    <div class="col-lg-4">
                        <div class="jumbotron">
                            <strong>Is Framing? --></strong>
                            <asp:Label ID="lblProjectDetails_IsFraming" runat="server" Text=""></asp:Label>
                            <br>
                            <br>
                            <strong>
                                Type of Floor Joist</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_TypeOfFloorJoist" runat="server" Text=""></asp:Label>
                            <br>
                            <br>
                            <strong>
                                Max Floor Joist Spacing</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_MaxFloorJoistSpacing" runat="server" Text=""></asp:Label>
                            <br>
                            <br>
                            <strong>
                                Type Of Ceiling Joist?</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_TypeOfCeilingJoist" runat="server" Text=""></asp:Label>
                            <br>
                            <br>
                            <strong>
                                Roofing Materials</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_RoofingMaterials" runat="server" Text=""></asp:Label>
                               
                            <br>
                            <br>
                            <strong>
                                Weight of Roofing Materials</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_WeightOfRoofingMaterials" runat="server" Text=""></asp:Label>
                            <br>
                            <br>
                            <strong>
                                Project Material Notes</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_ProjectMaterialNotes" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="jumbotron">
                                
                            <strong>Is Have Courier Plans? --></strong>
                            <asp:Label ID="lblProjectDetails_IsHaveCourierPlans" runat="server" Text=""></asp:Label>
                            <br>
                            <strong>
                                Courier to Whom</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_CourierToWhom" runat="server" Text=""></asp:Label>
                            <br>
                            <strong>
                                Courier to Address</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_CourierToAddress" runat="server" Text=""></asp:Label>
                            <br>
                            <br>
                            <strong>Is Have Email? --></strong>
                            <asp:Label ID="lblProjectDetails_IsHaveEmail" runat="server" Text=""></asp:Label>
                            <br>
                            <strong>
                                Email Address</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_EmailAddress" runat="server" Text=""></asp:Label>
                               
                        </div>
                        <div class="jumbotron">
                            <strong>Is client Will Pickup? --></strong>
                            <asp:Label ID="lblProjectDetails_IsClientWillPickup" runat="server" Text=""></asp:Label>
                            <br>
                            <strong>
                                Pickup By Person Name</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_PickUpByPersonName" runat="server" Text=""></asp:Label>
                            <br>
                            <strong>
                                Pickup By Person Phone Number</strong>
                            <br>
                            <asp:Label ID="lblProjectDetails_PickupByPersonPhoneNumber" runat="server" Text=""></asp:Label>
                            
                        </div>
                     
                    </div>
                </div>
            </div>
        </div>

        
        <asp:Label ID="lbltest" runat="server" Text="Label"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

