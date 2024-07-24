<template>
    <div class="weather-component">
        <h1>Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>

        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>

        <div v-if="post" class="content">
            <table>
                <thead>
                    <tr>
                        <th>ProductName</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="forecast in post" :key="forecast.date">
                        <td>{{ forecast.name }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent, ref, onMounted } from 'vue';

    export default defineComponent({
        setup() {
            const loading = ref(false);
            const post = ref(null);

            const fetchData = async () => {
                post.value = null;
                loading.value = true;
                const myHeaders = new Headers();
                myHeaders.append("Authorization", "••••••");

                const requestOptions = {
                    method: "GET",
                    headers: myHeaders,
                    redirect: "follow"
                };

                try {
                    const response = await fetch("https://localhost:5000/Catalog", requestOptions);
                    const result = await response.json();
                    console.log(result);
                    post.value = result;
                } catch (error) {
                    console.error(error);
                } finally {
                    loading.value = false;
                }
            };

            onMounted(() => {
                fetchData();
            });

            return {
                loading,
                post,
                fetchData
            };
        }
    });
</script>

<style scoped>
    th {
        font-weight: bold;
    }

    tr:nth-child(even) {
        background: #F2F2F2;
    }

    tr:nth-child(odd) {
        background: #FFF;
    }

    th, td {
        padding-left: .5rem;
        padding-right: .5rem;
    }

    .weather-component {
        text-align: center;
    }

    table {
        margin-left: auto;
        margin-right: auto;
    }
</style>
