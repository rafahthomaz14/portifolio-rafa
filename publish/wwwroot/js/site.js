// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
function sendMessage(event) {
    event.preventDefault(); // Impede o envio padrão do formulário

    const name = document.getElementById('name-field').value;
    const email = document.getElementById('email-field').value;
    const subject = document.getElementById('subject-field').value;
    const message = document.getElementById('message-field').value;

    // Montando a mensagem
    const fullMessage = `Nome: ${name}\nEmail: ${email}\nAssunto: ${subject}\nMensagem: ${message}`;

    // URL do WhatsApp (substitua 'YOUR_PHONE_NUMBER' pelo seu número)
    const phoneNumber = '16993696126'; // ex: '5516993696126' para o Brasil
    const whatsappUrl = `https://api.whatsapp.com/send?phone=${phoneNumber}&text=${encodeURIComponent(fullMessage)}`;

    // Abrindo a URL do WhatsApp em uma nova aba
    window.open(whatsappUrl, '_blank');

    // Limpar o formulário após o envio
    document.getElementById('contact-form').reset();
  }