// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function updateTextInputRangeOrganizovanostTure(val) {
    document.getElementById('inputRangeOrganizovanostTure').value=val; 
}

function updateTextInputRangeFizickaZahtevnostTure(val) {
    document.getElementById('inputRangeFizickaZahtevnostTure').value=val;
}

function updateTextInputRangeInformisanostVodica(val) {
    document.getElementById('inputRangeInformisanostVodica').value=val; 
}

function updateTextInputRangeDrustvenaAtmosfera(val) {
    document.getElementById('inputRangeDrustvenaAtmosfera').value=val; 
}

function updateTextInputRangeKonacnaOcena(val) {
    document.getElementById('inputRangeKonacnaOcena').value=val; 
} 

function nepopunjenKviz() {
    document.getElementById('ObavestenjeONepopunjenomKvizu').value="Morate odgovoriti na sva pitanja.";
}

// function proveriTacanOdgovor(id, correctAnswer) {
//     var element = document.getElementById('#id');
//     if (element.is(":checked"))
//     {
//         if (element.value != correctAnswer)
//             element.classList.add("IncorrectAnswer");
//         else element.classList.add("CorrectAnswer");
//     }    

// }