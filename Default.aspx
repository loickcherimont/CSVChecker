<%@ Page Title="CSV Checker" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="CSVChecker._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container d-lg-grid gap-3" aria-labelledby="title">
        <section class="text-center py-5 row">

            <span class="text-primary fw-semibold text-uppercase small">Outil de validation CSV
            </span>

            <h1 id="title" class="display-5 fw-bold mt-3 mb-3"><%: Title %></h1>

            <p class="text-muted fs-5 mx-auto mb-5" style="max-width: 600px;">
                Téléversez votre fichier CSV et laissez CSV Checker analyser sa structure
                et la cohérence de ses données avant de le transférer vers une autre application.
           
            </p>
            <asp:Label ID="SuccessMessage" runat="server" CssClass="alert alert-success" Visible="false">Votre fichier CSV est prêt pour le transfert !</asp:Label>
            <asp:Label ID="ErrorMessage" runat="server" CssClass="alert alert-danger" Visible="false"></asp:Label>

        </section>

        <section class="row g-5 align-items-stretch" aria-label="Outils de vérification CSV">
            <div class="col">
                <section class="h-100">
                    <h2 class="h4 fw-semibold mb-2">Téléversez votre fichier CSV
                    </h2>

                    <p class="text-muted mb-4">
                        Sélectionnez le fichier que vous souhaitez analyser.
                    </p>

                    <div class="row g-2 align-items-end">
                        <div class="col-12 col-sm-8">
                            <asp:FileUpload
                                ID="CsvFileUpload"
                                runat="server"
                                CssClass="form-control mw-100"
                                aria-describedby="csvFileHelp"
                                required="true" />
                        </div>
                        <div class="col-12 col-sm-4 d-grid">
                            <asp:Button ID="AnalyzeBtn" runat="server" Text="Analyser le CSV" OnClick="AnalyzeBtn_Click" CssClass="btn btn-primary w-100" />
                        </div>
                    </div>
                    <div id="csvFileHelp" class="form-text mt-2">
                        Format accepté : .csv
                    </div>
                </section>
            </div>
        </section>

        <section class="row mt-3" aria-label="Historique d'analyse CSV">
            <div>
                <section class="h-100">
                    <h2 class="h5 fw-semibold mb-3">Historique des analyses</h2>
                    <div class="table-responsive">
                        <asp:Table ID="TableHistory" runat="server" CssClass="table table-hover table-striped align-middle mb-0 csv-checker-table">
                            <asp:TableRow TableSection="TableHeader">
                                <asp:TableHeaderCell Scope="Column" CssClass="text-nowrap">ID</asp:TableHeaderCell>
                                <asp:TableHeaderCell Scope="Column" CssClass="text-nowrap">Nom du fichier</asp:TableHeaderCell>
                                <asp:TableHeaderCell Scope="Column" CssClass="text-nowrap">Date d'analyse</asp:TableHeaderCell>
                                <asp:TableHeaderCell Scope="Column" CssClass="text-nowrap">Statut</asp:TableHeaderCell>
                                <asp:TableHeaderCell Scope="Column" CssClass="text-nowrap">Détails</asp:TableHeaderCell>
                            </asp:TableRow>
                        </asp:Table>
                    </div>
                </section>
            </div>
        </section>

        <div class="text-center text-muted small mt-4 row">
            <p class="col">CSV Checker — Validation de fichiers simple et fiable.</p>
        </div>

    </main>

</asp:Content>
