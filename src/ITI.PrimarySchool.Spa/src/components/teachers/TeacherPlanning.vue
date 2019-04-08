<template>
    <div>
        <div class="mb-4 d-flex justify-content-between">
            <h1>Planning des professeurs</h1>

        </div>

        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Date</th>
                    <th>Nom</th>
                </tr>
            </thead>

            <tbody>

                <tr v-for="i of planningList">
                    <td>{{ i.planningId }}</td>
                    <td>{{ i.Date }}</td>
                    <td>{{ i.teacherName }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import { getPlanningListAsync, deletePlanningAsync } from '../../api/planningApi'

    export default {
        data() {
            return {
                id : null,
                planningList: []
            }
        },

        async mounted() {
            await this.refreshList();
            this.id = this.$route.params.id;
        },

        methods: {
            async refreshList() {
                try {
                    this.planningList = await getPlanningListAsync();
                }
                catch(e) {
                    console.error(e);
                }
            },

            async deletePlanning(planningId) {
                try {
                    await deletePlanningAsync(planningId);
                    await this.refreshList();
                }
                catch(e) {
                    console.error(e);
                }
            }
        }
    }
</script>

<style lang="scss">

</style>