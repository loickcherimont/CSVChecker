
<%@ Page Title="Documentation" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Docs.aspx.vb" Inherits="CSVChecker.Docs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container py-5" aria-labelledby="title">

        <h2 id="title" class="display-5 fw-bold mb-3"><%: Title %></h2>

        <p class="text-muted fs-5 mb-5">
            Découvrez comment CSV Checker valide et prépare vos fichiers pour le transfert.
        </p>

        <section class="mb-4">
            <h3 class="h5 fw-semibold text-primary">01. Téléversez votre fichier</h3>
            <p>
                Sélectionnez et téléversez votre fichier. Seul le format CSV est accepté, avec l'en-tête <code>Identifiant;Equipement;NumeroSerie;Proprietaire;DateAcquisition</code>
            </p>
        </section>

        <section class="mb-4">
            <h3 class="h5 fw-semibold text-primary">02. Analyse du fichier</h3>
            <p>
                CSV Checker analyse la structure du fichier et vérifie la cohérence des données
                par rapport aux règles de validation prédéfinies.
            </p>
        </section>

        <section class="mb-4">
            <h3 class="h5 fw-semibold text-primary">03. Résultat de la validation</h3>
            <p>
                Votre fichier est classé comme conforme ou non conforme.
                Si des erreurs sont détectées, elles sont signalées afin que vous puissiez les corriger.
            </p>
        </section>

        <section class="mb-4">
            <h3 class="h5 fw-semibold text-primary">04. Fichier prêt pour le transfert</h3>
            <p>
                Une fois validé, votre fichier CSV conforme est prêt à être transféré
                vers l'application cible.
            </p>
        </section>

    </main>

</asp:Content>
