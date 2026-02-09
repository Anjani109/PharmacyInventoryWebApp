// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggleSidebar() {
    document.querySelector(".sidebar").classList.toggle("show");
}

// ===== Sales Line Chart =====
const salesLineCtx = document.getElementById('salesLineChart').getContext('2d');
const salesLineChart = new Chart(salesLineCtx, {
    type: 'line',
    data: {
        labels: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
        datasets: [{
            label: 'Sales',
            data: [12000, 15000, 13000, 16000, 14000, 17000, 15000],
            borderColor: '#2C7BE5',
            backgroundColor: 'rgba(44,123,229,0.2)',
            fill: true,
            tension: 0.4
        }]
    },
    options: {
        responsive: true,
        plugins: { legend: { display: false } },
        scales: {
            y: { beginAtZero: true }
        }
    }
});

// ===== Stock Bar Chart =====
const stockBarCtx = document.getElementById('stockBarChart').getContext('2d');
const stockBarChart = new Chart(stockBarCtx, {
    type: 'bar',
    data: {
        labels: ['Antibiotics', 'Painkillers', 'Supplements', 'Vitamins'],
        datasets: [{
            label: 'Stock Levels',
            data: [300, 500, 200, 400],
            backgroundColor: '#34C38F',
            borderRadius: 5
        }]
    },
    options: { responsive: true, plugins: { legend: { display: false } } }
});

// ===== Category Pie Chart =====
const categoryPieCtx = document.getElementById('categoryPieChart').getContext('2d');
const categoryPieChart = new Chart(categoryPieCtx, {
    type: 'pie',
    data: {
        labels: ['Antibiotics', 'Painkillers', 'Supplements', 'Vitamins'],
        datasets: [{
            data: [30, 50, 10, 10],
            backgroundColor: ['#2C7BE5', '#34C38F', '#F1B44C', '#F46A6A']
        }]
    },
    options: { responsive: true }
});
