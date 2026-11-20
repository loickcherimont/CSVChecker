
<%@ Page Title="Documentation" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Docs.aspx.vb" Inherits="CSVChecker.Docs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container py-5" aria-labelledby="title">

        <h2 id="title" class="display-5 fw-bold mb-3"><%: Title %></h2>

        <p class="text-muted fs-5 mb-5">
            Discover how CSV Checker validates and prepares your files for transfer.
        </p>

        <section class="mb-4">
            <h3 class="h5 fw-semibold text-primary">01. Upload your file</h3>
            <p>
                Select and upload your file. Only CSV format is accepted, with the header <code>Identifiant;Equipement;NumeroSerie;Proprietaire;DateAcquisition</code>
            </p>
        </section>

        <section class="mb-4">
            <h3 class="h5 fw-semibold text-primary">02. File analysis</h3>
            <p>
                CSV Checker analyzes the file structure and checks data consistency
                against predefined validation rules.
            </p>
        </section>

        <section class="mb-4">
            <h3 class="h5 fw-semibold text-primary">03. Validation result</h3>
            <p>
                Your file is classified as compliant or non-compliant.
                If errors are detected, they are reported so you can correct them.
            </p>
        </section>

        <section class="mb-4">
            <h3 class="h5 fw-semibold text-primary">04. File ready for transfer</h3>
            <p>
                Once validated, your compliant CSV file is ready to be transferred
                to the target application.
            </p>
        </section>

    </main>

</asp:Content>
