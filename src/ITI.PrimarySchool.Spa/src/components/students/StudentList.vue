<template>
    <div>
        <div class="mb-4 d-flex justify-content-between">
            <h1>Gestion des élèves</h1>

            <div>
                <router-link class="btn btn-primary" :to="`students/create`"><i class="fa fa-plus"></i> Ajouter un élève</router-link>
            </div>
        </div>

        <table class="table table-striped table-hover table-bordered">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nom</th>
                    <th>Prénom</th>
                    <th>Date de naissance</th>
                    <th>Classe</th>
                    <th>Login github</th>
                    <th>Options</th>
                </tr>
            </thead>

            <tbody>
                <tr v-if="studentList.length == 0">
                    <td colspan="6" class="text-center">Il n'y a actuellement aucun élève.</td>
                </tr>

                <tr v-for="i of studentList">
                    <td>{{ i.studentId }}</td>
                    <td>{{ i.lastName }}</td>
                    <td>{{ i.firstName }}</td>
                    <td>{{ new Date(i.birthDate).toLocaleDateString() }}</td>
                    <td v-if="i.className == ''">Aucune Classe</td>
                    <td v-else>{{ i.className }}</td>
                    <td>{{ i.gitHubLogin }}</td>
                    <td>
                        <router-link :to="`students/class/${i.studentId}`">Classe</router-link>
                        <router-link :to="`students/edit/${i.studentId}`"><i class="fa fa-pencil"></i></router-link>
                        <a href="#" @click="deleteStudent(i.studentId)"><i class="fa fa-trash"></i></a>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script>
    import { getStudentListAsync, deleteStudentAsync } from '../../api/studentApi'

    export default {
        data() {
            return {
                studentList: []
            }
        },

        async mounted() {
            await this.refreshList();
        },

        methods: {
            async refreshList() {
                try {
                    this.studentList = await getStudentListAsync();
                }
                catch(e) {
                    console.error(e);
                }
            },

            async deleteStudent(studentId) {
                try {
                    await deleteStudentAsync(studentId);
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