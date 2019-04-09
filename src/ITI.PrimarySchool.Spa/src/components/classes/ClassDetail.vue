<template>
    <div>
        <div class="mb-4 d-flex justify-content-between">
            <h1>Détail de la classe</h1>
        </div>   

        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nom</th>
                </tr>
            </thead>

            <tbody>
                <tr v-if="classList.length == 0">
                    <td colspan="4" class="text-center">Il n'y a actuellement aucun élève dans la classe.</td>
                </tr>

                <tr v-for="i of classList" v-if="i.classId == id">
                    <td>{{ i.studentId }}</td>
                    <td>{{ i.studentName }}</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
import { getClassListAsync, deleteClassAsync, getClassDetailAsync } from '../../api/classApi'
import { getTeacherAsync } from '../../api/teacherApi'
import { state } from "../../state"

export default {
    data() {
        return {
            id: null,
            classList: []
        }
    },

    async mounted() {
        await this.refreshList();
        this.id = this.$route.params.id;
    },

    methods: {
        async refreshList() {
            try {
                state.isLoading = true;
                this.classList = await getClassDetailAsync();
            }
            catch (e) {
                console.error(e);
                state.exceptions.push(e);
            }
            finally {
                state.isLoading = false;
            }
        }
    }
}
</script>

<style lang="scss">

</style>