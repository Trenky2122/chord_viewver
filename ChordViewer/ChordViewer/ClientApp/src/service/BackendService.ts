import axios, {AxiosResponse} from "axios";
import {Collection, Tab, User} from "../models/BackendModels";
export class BackendService{
    private static axios = axios.create({
        withCredentials: true
    })
    private static config = require("./config.json");
    private static baseUrl = BackendService.config.baseUrl;
    public static LogIn(username: string, password: string): Promise<AxiosResponse<User>>{
        const params = new URLSearchParams();
        params.append('username', username);
        params.append('password', password);
        return BackendService.axios.post(BackendService.baseUrl+"api/User/login", params);
    }

    public static LogOut(): Promise<AxiosResponse<User>>{
        return BackendService.axios.delete(BackendService.baseUrl+"api/User/logout");
    }

    public static GetCurrentUser(): Promise<AxiosResponse<User>>{
        return BackendService.axios.get(BackendService.baseUrl+"api/User/me");
    }

    public static GetTabsForToneKey(toneKey: string): Promise<AxiosResponse<Tab[]>>{
        return BackendService.axios.get(BackendService.baseUrl + "api/Tab/tabsForToneKey/"+escape(toneKey));
    }

    public static SaveTab(tab: Tab): Promise<AxiosResponse>{
        return BackendService.axios.post(BackendService.baseUrl+"api/Tab/createTab", tab);
    }

    public static CreateUser(username: string, password: string){
        const params = new URLSearchParams();
        params.append('username', username);
        params.append('password', password);
        return BackendService.axios.post(BackendService.baseUrl+"api/User/createUser", params);
    }

    public static UserOwnCollections(userId: number): Promise<AxiosResponse<Collection>>{
        return BackendService.axios.get(BackendService.baseUrl + "api/Collection/collectionsForUser/"+userId);
    }

    public static UserSharedCollections(userId: number): Promise<AxiosResponse<Collection>>{
        return BackendService.axios.get(BackendService.baseUrl + "api/Collection/collectionsSharedWithUser/"+userId);
    }

    public static CreateCollection(collection: Collection): Promise<Collection>{
        return BackendService.axios.post(BackendService.baseUrl+"api/Collection", collection);
    }
}