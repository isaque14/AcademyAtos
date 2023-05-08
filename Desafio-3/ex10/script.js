function toggleFields() {
    var pessoaFisica = document.getElementById("pessoaFisica");
    var pessoaJuridica = document.getElementById("pessoaJuridica");
    var cpfField = document.getElementById("cpfField");
    var cnpjField = document.getElementById("cnpjField");
    var dataNascimentoField = document.getElementById("dataNascimentoField");
    var cepField = document.getElementById("cepField");
    
    cpfField.disabled = !pessoaFisica.checked;
    cnpjField.disabled = !pessoaJuridica.checked;
    dataNascimentoField.disabled = !pessoaFisica.checked;

    return validarCampos();
  }

  function validarCampos() {
    var cepField = document.getElementById("cepField");
    var telefoneField = document.getElementById("telefone");
    
    var cep = cepField.value;
    var telefone = telefoneField.value;

    if (cep.length > 0 && !/^\d+$/.test(cep)) {
      alert("O campo CEP deve conter somente números.");
      cepField.focus();
      return false;
    }
    
    if (!/^\d+$/.test(telefone)) {
      alert("O campo Telefone deve conter somente números.");
      telefoneField.focus();
      return false;
    }
    
    alert("Usuário Cadastrado com Sucesso!")
    return true;
  }