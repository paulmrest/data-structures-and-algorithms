const cheerio = require('cheerio');

let starWarsPeople = [
  {
    "name": "Luke Skywalker",
    "height": "172",
    "eye_color": "blue"
  },
  {
    "name": "C-3PO",
    "height": "167",
    "eye_color": "yellow"
  },
  {
    "name": "R2-D2",
    "height": "96",
    "eye_color": "red"
  }
];

let $ = createSnippetWithJQuery(`
<main>
  <section id="template">
    <h2></h2>
    <h3></h3>
    <p></p>
  </section>
</main>
`);

const templateWithJQuery = () => {
  console.log('templateWithJQuery');
  let template = $('#template').html();
  console.log(template);
  for (let onePerson in starWarsPeople)
  {
    let templateCopy = template.clone();
    templateCopy.find('h2').text(onePerson.name);
    templateCopy.find('h3').text(onePerson.height);
    templateCopy.find('p').text(onePerson.eye_color);
    $('main').append(templateCopy);
  }
}

function createSnippetWithJQuery(html){
  return cheerio.load(html);
}

templateWithJQuery();