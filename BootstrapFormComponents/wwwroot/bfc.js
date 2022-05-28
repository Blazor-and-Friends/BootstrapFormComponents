let bfc = window['bfc'] = {

    autoFocusFirstInput() {
        let firstInputEl = document.querySelector('input');
        if (firstInputEl) firstInputEl.focus();
        else {
            firstInputEl = document.querySelector('textarea');
            if (firstInputEl) firstInputEl.focus();
        }
    },

    scrollToFormTop: function () {
        let formEl = document.querySelector('form');

        if (formEl) {
            formEl.scrollIntoView();
        }
    },

    setSelectAll: function (elementId) {
        let el = document.getElementById(elementId);
        if (el) {
            el.setAttribute('select-all-on-focus', '');
        }
    }
}

function selectAllOnFocus(e) {
    let el = e.target;
    if (el.hasAttribute('select-all-on-focus')) {
        el.select();
    }
}

window.addEventListener('DOMContentLoaded', () => {
    document.querySelector('body').addEventListener('focus', function (e) {
        selectAllOnFocus(e);
    }, true);

    setTimeout(function () {
        bfc.autoFocusFirstInput();
    }, 1000);
});