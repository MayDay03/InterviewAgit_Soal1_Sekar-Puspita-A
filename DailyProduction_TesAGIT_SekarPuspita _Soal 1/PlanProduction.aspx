<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlanProduction.aspx.cs" Inherits="DailyProduction_TesAGIT_SekarPuspita__Soal_1.PlanProduction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="card p-4"> 
        <h2>Production Plan Adjustment</h2>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Enter total cars to produce: "></asp:Label>
        <input type="number" class="form-control mb-3" id="txtTotalProduction" runat="server"></input> 
        <asp:Button CssClass="btn btn-info" ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" />
        <br />
        <br />

        <asp:Label ID="lblOutput" runat="server" Text=""></asp:Label>

        <!-- Card untuk menampilkan Production Plan -->
        <div class="col-lg-12 mt-4"> 
            <div class="card">
                <div class="card-header">
                    <strong class="card-title">Production Plan</strong>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="gvProductionPlan" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="Senin" HeaderText="Senin" />
                                <asp:BoundField DataField="Selasa" HeaderText="Selasa" />
                                <asp:BoundField DataField="Rabu" HeaderText="Rabu" />
                                <asp:BoundField DataField="Kamis" HeaderText="Kamis" />
                                <asp:BoundField DataField="Jumat" HeaderText="Jumat" />
                                <asp:BoundField DataField="Sabtu" HeaderText="Sabtu" />
                                <asp:BoundField DataField="Minggu" HeaderText="Minggu" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
