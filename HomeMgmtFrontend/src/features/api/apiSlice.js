import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { BASE_URL, API_TAGS } from "../../constants/apiConstants";

export const apiSlice = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
  tagTypes: [API_TAGS.USER_ACCOUNTS],
  endpoints: (builder) => ({
    // USER ENDPOINTS

    getUsers: builder.query({
      query: () => "userAccount",
      method: "GET",
      // transformResponse: (res) => res.sort((a, b) => b.id - a.id),
      providesTags: [API_TAGS.USER_ACCOUNTS],
    }),

    createUser: builder.mutation({
      query: (newUser) => ({
        url: "userAccount",
        method: "POST",
        body: newUser,
      }),
      invalidatesTags: [API_TAGS.USER_ACCOUNTS],
    }),

    updateUser: builder.mutation({
      query: (user) => ({
        url: "userAccount",
        method: "PUT",
        body: user,
      }),
      invalidatesTags: [API_TAGS.USER_ACCOUNTS],
    }),

    deleteUser: builder.mutation({
      query: (id) => ({
        url: `userAccount/${id}`,
        method: "DELETE",
      }),
      invalidatesTags: [API_TAGS.USER_ACCOUNTS],
    }),

    //OTHER ENDPOINTS
  }),
});

export const {
  useGetUsersQuery,
  useCreateUserMutation,
  useUpdateUserMutation,
  useDeleteUserMutation,
} = apiSlice;
