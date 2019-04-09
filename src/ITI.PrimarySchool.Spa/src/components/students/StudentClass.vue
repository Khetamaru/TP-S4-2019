<template>
    <div>
        <div class="mb-4">
            <h1>Editer la classe d'un élève</h1>
        </div>

        <form @submit="onSubmit($event)">

            <div class="form-group">
                <label>Numéro de Classe</label>
                <select class="form-control" v-model="item.classId">
                    <option v-for="i of classList" :key="i.classId" :value="i.classId">
                        {{i.name}}
                    </option>
                </select>
            </div>

            <button type="submit" class="btn btn-primary">Sauvegarder</button>
        </form>
    </div>
</template>

<script>
    import { getStudentAsync, classAssignStudentAsync } from '../../api/studentApi'
    import { getClassListAsync} from '../../api/classApi'

    export default {

        data () {
            return {
                item: {},
                mode: null,
                id: null,
                errors: [],
                classList: []
            }
        },

        async mounted() {
            this.mode = this.$route.params.mode;
            this.id = this.$route.params.id;
            this.item.studentId = this.$route.params.id;
            
            try {
                this.classList = await getClassListAsync();
            }
            catch (e) {
                console.error(e);
                state.exceptions.push(e);
            }
        },

        methods: {
            async refreshList() {
                try {
                    this.classList = await getClassListAsync();
                }
                catch(e) {
                    console.error(e);
                }
            },

            async onSubmit(event) {
                event.preventDefault();

                try {

                    await classAssignStudentAsync(this.item);
                    this.$router.replace('/students');
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