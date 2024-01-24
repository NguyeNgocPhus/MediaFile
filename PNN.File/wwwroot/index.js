
console.log("hót", location.hostname)

console.log("hót", location.port)
class FileManager extends HTMLElement {
    connectedCallback() {
        // Use fetch API to get the content from the external HTML file
        fetch('http://localhost:5050/lib/roxyfm/file-manager.html')
            .then(response => response.text())
            .then(htmlContent => {
                // Set the innerHTML of the custom element with the content from the external file
                this.innerHTML = htmlContent;
                
            });
    }
}
customElements.define('file-manager', FileManager);