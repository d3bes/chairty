
  let  data= {
        full_name: ' سعيد احمد رياض برقى',
        id_number: '4644648687448468',
        birthdate: '1990-01-01',
        mobile_number:'8946846',
        city:'الرياض',
        bank_account_number: '64684612354687241',
        children_count:4,
        income_support:'لا'
        
    }

let full_name = document.getElementById('full_name');
full_name.value = data.full_name;

let id_number = document.getElementById('id_number');
id_number.value = data.id_number;

let birthdate = document.getElementById('birthdate');
birthdate.value = data.birthdate;

let mobile_number = document.getElementById('mobile_number');
mobile_number.value= data.mobile_number;

let city = document.getElementById('city');
city.value = data.city;

let bank_account_number = document.getElementById('bank_account_number');
bank_account_number.value = data.bank_account_number;

let children_count = document.getElementById('children_count');
children_count.value = data.children_count;

let income_support_yes = document.getElementById('income_support-yes');
let income_support_no = document.getElementById('income_support-no');

if (data.income_support === 'نعم') {
    income_support_yes.checked = true;
  } else if (data.income_support === 'لا') {
    income_support_no.checked = true;
  }